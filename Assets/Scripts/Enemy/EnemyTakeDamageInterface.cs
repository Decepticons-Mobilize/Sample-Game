using UnityEngine;

public class EnemyTakeDamageInterface : MonoBehaviour
{
    public interface IDDamage
    { 
        void TakeDamage(int damage);
    }
}
