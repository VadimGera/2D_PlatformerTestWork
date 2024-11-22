using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalOpenScript : MonoBehaviour
{
    public string currentSceneName;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            RestartLevel();
        }
    }

    void RestartLevel()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentSceneName);
    }
}
