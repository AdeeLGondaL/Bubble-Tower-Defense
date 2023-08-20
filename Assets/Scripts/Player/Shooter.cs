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
        pool = new ObjectPool<CannonBall>((() => { return Instantiate(cannonBallPrefab, transform.position, Quaternion.identity); }),
            ball =>
            {
                ball.gameObject.SetActive(true);
                //ball.GetComponent<Rigidbody>().AddForce(-this.transform.right * force, ForceMode.Impulse);
                if (Physics.Raycast(crossHair.transform.position, crossHair.transform.forward, out hit, ballRange))
                {
                    Debug.Log(hit.transform.position);
                    Debug.DrawRay(crossHair.transform.position, crossHair.transform.forward * 50f, Color.green);
                    ball.transform.DOMove(hit.transform.position, 0.5f);
                }
                ball.GetComponent<CannonBall>().ballColor = ballColor;
                ball.Init(DestroyBall);
            },
            ball => { ball.gameObject.SetActive(false);
                ball.gameObject.transform.position = this.transform.position;
                //ball.GetComponent<Rigidbody>().AddForce(this.transform.right * force, ForceMode.Impulse);
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
            smokeParticle.startColor = ballColor;
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
