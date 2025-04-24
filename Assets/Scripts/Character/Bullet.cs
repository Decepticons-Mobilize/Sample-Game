using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using static EnemyTakeDamageInterface;

public class Bullet : MonoBehaviour
{
    [SerializeField] private int bulletDamage = 20;
    private MutantEnemy mutantEnemy;
    private void OnCollisionEnter(Collision collision)
    {
        Enemy enemy = collision.collider.GetComponent<Enemy>();

        if (enemy != null)
        {
            enemy.TakeDamage(bulletDamage);
            Destroy(gameObject);
        }
    }
}
