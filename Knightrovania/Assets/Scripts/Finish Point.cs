using UnityEngine;

public class FinishPoint : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Knightro"))
        {
            SceneController.instance.NextLevel();
        }
    }
}