using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using System;

public class ArgoDetection : MonoBehaviour
{
    public event Action<Transform> OnAggro = delegate { };

    public float detectionRadius = 10.0f;
    public Transform player;
    private NavMeshAgent navAgent;

    private void Awake()
    {
        navAgent = GetComponent<NavMeshAgent>();
    }
    private void Update()
    {
        if (player != null)
        {
            float distanceToPlayer = Vector3.Distance(transform.position, player.position);
            if (distanceToPlayer <= detectionRadius)
            {
                OnAggro(player);
                navAgent.SetDestination(player.position);
            }
        }
    }
}
