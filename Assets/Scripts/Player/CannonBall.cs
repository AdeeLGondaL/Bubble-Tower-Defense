using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CannonBall : MonoBehaviour
{
    private Action<CannonBall> killAction;
    public Color ballColor;
    public GameObject greenEnemy;
    public GameObject yellowEnemy;
    public GameObject blueEnemy;
    public GameObject redEnemy;
    private bool hasCollided = false;

    public void Init(Action<CannonBall> killAction)
    {
        this.killAction = killAction;
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.layer == LayerMask.NameToLayer("Enemy") && !hasCollided)
        {
            Debug.Log("Collision");
            hasCollided = true;
            other.gameObject.TryGetComponent<Enemy>(out Enemy enemy);
            

            if (enemy.enemyColor.Equals(ballColor))
            {
                //Destroy Enemy Group

                Destroy(other.gameObject.transform.parent.gameObject);
            }
            else if (!enemy.enemyColor.Equals(ballColor))
            {
                //Instaniate Group of Ball Color

                Debug.Log("Enters FUNCTIPM");
                var newEnemy = Instantiate(EnemyGroupToSpawn(), other.gameObject.transform.position, other.gameObject.transform.rotation);
                newEnemy.TryGetComponent<EnemyGroup>(out EnemyGroup enemyGroup);
                enemyGroup.Cannon = other.gameObject.GetComponent<EnemyNavigation>().Cannon;
                
            }

        }

        if (other.gameObject.layer == LayerMask.NameToLayer("Enemy") || other.gameObject.layer == LayerMask.NameToLayer("Plane"))
        {
            hasCollided = false;
            killAction(this);
        }
    }


    private GameObject EnemyGroupToSpawn()
    {
        //Debug.Log(ballColor.ToHexString());
        //Debug.Log(greenEnemy.GetComponentInChildren<Enemy>().enemyColor.ToHexString());

        if (ballColor.Equals(greenEnemy.GetComponentInChildren<Enemy>().enemyColor))
        {
            return greenEnemy;
        }
        else if (ballColor.Equals(redEnemy.GetComponentInChildren<Enemy>().enemyColor))
        {
            return redEnemy;
        }
        else if (ballColor.Equals(blueEnemy.GetComponentInChildren<Enemy>().enemyColor)) 
        {
            return blueEnemy;
        }
        else if (ballColor.Equals(yellowEnemy.GetComponentInChildren<Enemy>().enemyColor))
        {
            return yellowEnemy;
        }

        return null;
    }
}
