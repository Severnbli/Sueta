using UnityEngine;

public class Collectible : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            VictoryManager victoryManager = FindObjectOfType<VictoryManager>();
            if (victoryManager != null)
            {
                victoryManager.Collect();
                Destroy(gameObject);
            }
        }
    }
}