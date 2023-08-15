using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Lean.Touch;
using TMPro;
using UnityEngine;
using UnityEngine.Pool;

public class Shooter : MonoBehaviour
{
    [SerializeField] private Animator playerAnimator;
    public CannonBall cannonBallPrefab;
    private ObjectPool<CannonBall> pool;
    private bool canShoot = false;
    public float force;

    private static readonly int gettingReadyTrigger = Animator.StringToHash("getting ready");
    private static readonly int shootTrigger = Animator.StringToHash("shoot");
    // Start is called before the first frame update
    void Start()
    {
        pool = new ObjectPool<CannonBall>((() => { return Instantiate(cannonBallPrefab, this.transform); }),
            ball =>
            {
                ball.gameObject.SetActive(true);
                ball.GetComponent<Rigidbody>().AddForce(-ball.transform.right * force);
                ball.Init(DestroyBall);
            },
            ball => { ball.gameObject.SetActive(false);
                ball.gameObject.transform.position = this.transform.position;
            },
            ball => { Destroy(ball.gameObject); },
            false,
            15, 30);

        for (int i = 0; i < 15; i++)
        {
            // var balli = pool.Get();
            // pool.Release(balli);
        }
}

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ReadyCannon(LeanFinger leanFinger)
    {
        if (leanFinger.Old)
        {
            Debug.Log("Ready");
            playerAnimator.SetTrigger(gettingReadyTrigger);
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
            Debug.Log("Shoot");
        }
    }

    private void DestroyBall(CannonBall cannonBall)
    {
        pool.Release(cannonBall);
    }
}
