using System.Collections;
using System.Collections.Generic;

using UnityEngine.AI;
using UnityEngine;


public class EnemyChase: MonoBehaviour
{

    public Transform target;
    public float chaseRange = 10f;

    private NavMeshAgent agent;
    private float distanceToTarget = Mathf.Infinity;
    private bool isChasing = false;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        distanceToTarget = Vector3.Distance(target.position, transform.position);

        if (distanceToTarget <= chaseRange)
        {
            isChasing = true;
        }
        else
        {
            isChasing = false;
        }

        if (isChasing)
        {
            agent.SetDestination(target.position);
        }
        else
        {
            agent.SetDestination(transform.position);
        }
    }
}