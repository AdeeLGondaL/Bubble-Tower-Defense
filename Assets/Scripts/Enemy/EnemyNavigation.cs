using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyNavigation : MonoBehaviour
{
    private NavMeshAgent m_Agent;
    public Transform Cannon;
    public EnemyGroup enemyGroup;

    // Start is called before the first frame update
    void Start()
    {
        enemyGroup = GetComponentInParent<EnemyGroup>();
        Cannon = enemyGroup.Cannon;
       m_Agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Cannon == null)
        {
            Cannon = enemyGroup.Cannon;
        }
        m_Agent.destination = Cannon.position;
    }
}
