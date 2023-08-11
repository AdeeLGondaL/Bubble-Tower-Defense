using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] private float moveSpeed;

    private void Update()
    {
        EnemyMovement();
    }

    private void EnemyMovement()
    {
        Vector3 moveDir = Vector3.forward;
        transform.position += moveDir * moveSpeed * Time.deltaTime;
    }
}
