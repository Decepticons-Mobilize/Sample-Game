using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;

public class MutantEnemy : Enemy
{
    private ArgoDetection aggroDetection;
    private NavMeshAgent agent;
    public MutantEnemy() : base(100)
    {
        
    }
    
    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        aggroDetection = GetComponent<ArgoDetection>();
        aggroDetection.OnAggro += AggroDection_TowardPlayer;
    }

    private void AggroDection_TowardPlayer(Transform target) 
    {
        if (agent != null && target != null)
        {
            agent.SetDestination(target.position);
        }
    }

    public override void Shoot()
    {
        Destroy(gameObject);
    }

    public override void TakeDamage(int damageAmount)
    {
        base.TakeDamage(damageAmount);  
    }
}
