using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class KeyCollector : MonoBehaviour
{
    public TextMeshProUGUI KeyIndicator;
    private int totalKeys;
    private int collectedKeys = 0;

    void Start()
    {
        totalKeys = GameObject.FindGameObjectsWithTag("Key").Length;

        UpdateKeyIndicator();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Key"))
        {
            collectedKeys++;
            Destroy(collision.gameObject);
            UpdateKeyIndicator();
        }
    }

    void UpdateKeyIndicator()
    {
        KeyIndicator.text = $"Собрано {collectedKeys}/{totalKeys} ключей";
    }
}
