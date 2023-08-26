using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyGroup : MonoBehaviour
{
    public Transform Cannon;
    [SerializeField] private ParticleSystem blood;
    [SerializeField] private List<GameObject> soldiers;

    public void Start()
    {
        
    }

    public void Die()
    {
        blood.gameObject.transform.position = soldiers[0].transform.position;
        foreach (var soldier in soldiers)
        {
            soldier.SetActive(false);
        }
        blood.Play();
        GameManager.Instance.numberOfRemainingEnemies--;
        Destroy(this);
    }
}
