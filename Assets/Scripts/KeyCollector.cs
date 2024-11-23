using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class KeyCollector : MonoBehaviour
{
    public TextMeshProUGUI KeyIndicator;
    public int TotalKeys { get; private set; }
    public int CollectedKeys { get; private set; } = 0;

    void Start()
    {
        TotalKeys = GameObject.FindGameObjectsWithTag("Key").Length;

        UpdateKeyIndicator();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Key"))
        {
            CollectedKeys++;
            Destroy(collision.gameObject);
            UpdateKeyIndicator();
        }
    }

    void UpdateKeyIndicator()
    {
        KeyIndicator.text = $"Собрано {CollectedKeys}/{TotalKeys} кристаллов";
    }
}
