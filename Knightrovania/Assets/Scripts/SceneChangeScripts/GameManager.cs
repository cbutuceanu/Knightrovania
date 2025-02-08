using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public SceneManager sceneManager;
    
    
    [SerializeField]
    private int maxLives = 3;

    [SerializeField] private int currentLives = 3;

    public event Action onDeath;
    public float timer;
    
    
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if(instance != this)
        {
            Destroy(gameObject);
        }
        
    }

    private void Update()
    {
        
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created

    // Update is called once per frame
    private void Start()
    {
    }

    public void OnDeath()
    {
        currentLives -= 1;
        Debug.Log("Player Died. Remaining Lives: " + currentLives);

        if (currentLives <= 0)
        {
            Debug.Log("No lives left! Loading Game Over scene...");
            SceneManager.LoadScene(4);
        }
        else
        {
            var temp = SceneManager.GetActiveScene();
            SceneManager.LoadScene(temp.buildIndex);
        }
        
    }
    
    
    
    
    
}
