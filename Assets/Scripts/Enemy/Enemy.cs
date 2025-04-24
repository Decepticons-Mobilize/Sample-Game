using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.EventSystems;

public abstract class Enemy : MonoBehaviour
{
    public int Health {get; set;}
    
    public Enemy(int health) 
    { 
        Health = health;
    }

    public virtual void TakeDamage(int damageAmount) 
    { 
        Health -= damageAmount;

        if (Health <= 0)

        {
            Die();
        }
    }
    public abstract void Shoot();

    protected virtual void Die()
    {
        Destroy(gameObject);
    }
}
