using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishPoint : MonoBehaviour
{
    [SerializeField]
    SceneManager sceneManager;

    [SerializeField] 
    private int buildIndex;

    public static event Action<int> onDoorEnter;

   

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Knightro"))
        {
            onDoorEnter?.Invoke(buildIndex);
        }
    }
}