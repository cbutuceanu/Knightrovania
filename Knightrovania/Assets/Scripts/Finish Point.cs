using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishPoint : MonoBehaviour
{
    [SerializeField]
    SceneManager sceneManager;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Knightro"))
        {
            SceneManager.LoadScene("Levlel 2");
        }
    }
}