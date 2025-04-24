using UnityEngine;

public class ShieldEffect : MonoBehaviour
{
    public GameObject shieldPrefab;

    private GameObject auraInstance;

    void Start()
    {
        TurnOnEffect();
    }

    private void TurnOnEffect() 
    {
        GameObject player = GameObject.FindWithTag("Player");
        if (player != null && shieldPrefab != null ) 
        {
            auraInstance = Instantiate(shieldPrefab, player.transform.position, Quaternion.identity);
            auraInstance.transform.SetParent(player.transform);
            auraInstance.transform.localPosition = new Vector3(0, 1.5f, 0);
        }
    }
}
