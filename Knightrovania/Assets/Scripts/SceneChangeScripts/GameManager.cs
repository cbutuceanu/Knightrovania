using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public SceneManager sceneManager;
    
    [SerializeField]
    private int maxLives = 3;

    private int score;

    [SerializeField] private int currentLives = 3;

    public event Action onDeath;
    public float gameTimer = 180f;
    private bool isTimerActive;
    
    
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
        if (isTimerActive)
        {
            gameTimer -= Time.deltaTime;
            //clamp this shit so it cant go past zero
            //the moment it does everything should stop

            if (gameTimer == 0)
            {
                SceneManager.LoadScene(4);
            }
            
            //Format the timer to send to the UI
        }
       
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created

    // Update is called once per frame
    private void Start()
    {
        isTimerActive = true;
        EnemyBehavior.onKill += ScoreUpdate;
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

    private void ScoreUpdate(int value)
    {
        score += value;
        Debug.Log("Score: " + score);
    }
    
    
    
    
    
}
