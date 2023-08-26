using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyGroup : MonoBehaviour
{
    public static int enemyGroupCount = 0;
    public static bool initialized;
    public Transform Cannon;
    [SerializeField] private ParticleSystem blood;
    [SerializeField] private List<GameObject> soldiers;
    public GameManager gameManager;

    public void Start()
    {
        enemyGroupCount += 1;
    }

    public void Die()
    {
        blood.gameObject.transform.position = soldiers[0].transform.position;
        foreach (var soldier in soldiers)
        {
            soldier.SetActive(false);
        }
        blood.Play();
        enemyGroupCount--;

        if (enemyGroupCount == 0)
        {
            gameManager.GameWon();
        }
        Destroy(this);
    }
}
