using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyNavigation : MonoBehaviour
{
    private NavMeshAgent m_Agent;
    [SerializeField] private Transform Cannon;

    // Start is called before the first frame update
    void Start()
    {
       m_Agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        m_Agent.destination = Cannon.position;
    }
}
