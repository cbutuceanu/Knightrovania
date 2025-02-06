using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public SceneManager sceneManager;
    
    //The game manager should ideally handled all the operations for what could happens on levels 1 and 2
    //For the menu scripts they should have their own managers and scripts if needed.

    //Event that is triggered when you die
    //Once this event is called the game manager will handle the appropriate code to deal with it
   

    [SerializeField]
    private int maxLives = 3;

    [SerializeField] private int currentLives = 3;

    private GameObject player;
    
    
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

    // Start is called once before the first execution of Update after the MonoBehaviour is created

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void MainMenu()
    {
        SceneManager.LoadScene("Starting screen");

    }

    public void OnDeath()
    {
        currentLives = Mathf.Clamp((currentLives - 1), 0, maxLives);
        Debug.Log("Player Died. Remaining Lives: " + currentLives);

        if (currentLives <= 0)
        {
            Debug.Log("No lives left! Loading Game Over scene...");
            SceneManager.LoadScene("Game Over");
        }

        var temp = SceneManager.GetActiveScene();
        SceneManager.LoadScene(temp.buildIndex);
    }
    
    
    
    
    
}
