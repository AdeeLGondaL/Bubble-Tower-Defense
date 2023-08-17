using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBall : MonoBehaviour
{
    private Action<CannonBall> killAction;
    public Color ballColor;
    public GameObject greenEnemy;
    public GameObject yellowEnemy;
    public GameObject blueEnemy;
    public GameObject redEnemy;

    public void Init(Action<CannonBall> killAction)
    {
        this.killAction = killAction;
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            other.gameObject.TryGetComponent<Color>(out Color enemyColor);

            if (enemyColor.Equals(ballColor))
            {
                //Destroy Enemy Group

                Destroy(other.gameObject.transform.parent.gameObject);
            }
            else if (!enemyColor.Equals(ballColor))
            {
                //Instaniate Group of Ball Color

                Instantiate(EnemyGroupToSpawn(), other.gameObject.transform.position, other.gameObject.transform.rotation);

            }

        }

        if(other.gameObject.layer == LayerMask.NameToLayer("Enemy") || other.gameObject.layer == LayerMask.NameToLayer("Plane")) killAction(this);
    }


    private GameObject EnemyGroupToSpawn()
    {
        if (ballColor.Equals(greenEnemy.GetComponentInChildren<Color>()))
        {
            return greenEnemy;
        }
        else if (ballColor.Equals(redEnemy.GetComponentInChildren<Color>()))
        {
            return redEnemy;
        }
        else if (ballColor.Equals(blueEnemy.GetComponentInChildren<Color>())) 
        {
            return blueEnemy;
        }
        else if (ballColor.Equals(yellowEnemy.GetComponentInChildren<Color>()))
        {
            return yellowEnemy;
        }

        return null;
    }
}
