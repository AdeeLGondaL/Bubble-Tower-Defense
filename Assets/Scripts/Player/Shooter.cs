using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using JetBrains.Annotations;
using Lean.Touch;
using TMPro;
using UnityEngine;
using UnityEngine.Pool;
using Random = System.Random;

public class Shooter : MonoBehaviour
{
    [SerializeField] CannonBall cannonBallPrefab;
    [SerializeField] private Animator playerAnimator;
    [SerializeField] public ParticleSystem smokeParticle;
    [SerializeField] private List<Color> ballColors;
    [SerializeField] private GameObject crossHair;
    [SerializeField] private Material cannonColor;
    public float force, ballRange;
    private ObjectPool<CannonBall> pool;
    private bool canShoot = false;
    private Color ballColor;
    RaycastHit hit;

    private static readonly int gettingReadyTrigger = Animator.StringToHash("getting ready");
    private static readonly int shootTrigger = Animator.StringToHash("shoot");
    // Start is called before the first frame update
    void Start()
    {
        pool = new ObjectPool<CannonBall>((() => { return Instantiate(cannonBallPrefab, transform.position, crossHair.transform.rotation); }),
            ball =>
            {
                ball.gameObject.transform.position = crossHair.transform.position;
                ball.gameObject.transform.rotation = crossHair.transform.rotation;
                ball.gameObject.SetActive(true);
                // ball.GetComponent<Rigidbody>().AddForce(crossHair.transform.forward * force, ForceMode.Impulse);
                if (Physics.Raycast(crossHair.transform.position, crossHair.transform.forward, out hit, ballRange))
                {
                    //Debug.Log($"{hit.transform.name},{hit.point}");
                    Debug.DrawRay(crossHair.transform.position, crossHair.transform.forward * ballRange, Color.green, 3f);
                    ball.transform.DOMove(hit.point, 1f);
                }
                ball.GetComponent<CannonBall>().ballColor = ballColor;
                ball.hitParticleSystem.SetActive(true);
                ball.Init(DestroyBall);
            },
            ball => { ball.gameObject.SetActive(false);
                ball.hitParticleSystem.SetActive(false);
                ball.gameObject.transform.position = crossHair.transform.position;
                ball.gameObject.transform.rotation = crossHair.transform.rotation;
                //ball.GetComponent<Rigidbody>().AddForce(-crossHair.transform.forward * force, ForceMode.Impulse);
            },
            ball => { Destroy(ball.gameObject); },
            false,
            15, 30);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ReadyCannon(LeanFinger leanFinger)
    {
        if (leanFinger.Old)
        {
            playerAnimator.SetTrigger(gettingReadyTrigger);
            Random rnd = new Random();
            ballColor = ballColors[rnd.Next(ballColors.Count)];
            cannonColor.color = ballColor;
            smokeParticle.startColor = ballColor;
            GameUIManager.Instance.SetColor(ballColor);
            canShoot = true;
        }
    }

    public void Shoot(LeanFinger leanFinger)
    {
        if (leanFinger.Up && canShoot)
        {
            var cannonBall = pool.Get();
            canShoot = false;
            playerAnimator.SetTrigger(shootTrigger);
        }
    }

    private void DestroyBall(CannonBall cannonBall)
    {
        pool.Release(cannonBall);
    }
}
