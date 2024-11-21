using UnityEngine;

public class HealingItem : MonoBehaviour
{
    public int healingAmount = 20;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerHealth playerHealth = collision.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.Heal(healingAmount);
            }
            
            Destroy(gameObject);
        }
    }
}
