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
    public GameManager gameManager;

    public void Start()
    {
        if (gameManager != null)
        {
            gameManager.RegisterEnemyGroup(this);
        }
    }

    public void Die()
    {
        foreach (var soldier in soldiers)
        {
            soldier.SetActive(false);
        }
        blood.Play();
        gameManager.EnemyGroupDefeated(this);
        Destroy(this);
    }
}
