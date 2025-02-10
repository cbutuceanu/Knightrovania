using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public SceneManager SceneManager;
    
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
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this);
        }
<<<<<<< Updated upstream
=======
        
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
       
>>>>>>> Stashed changes
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
        if (currentLives < 0)
        {
            Time.timeScale = 0;
            OnLoss();
        }

        var temp = SceneManager.GetActiveScene();
        SceneManager.LoadScene(temp.buildIndex);
    }
    
    public void OnLoss()
    {
        //this is where the death processes are handled when someone invokes the on death event
        
        //From here ther are two choices on how to handle coding the moving parts
        //1. we can have it do the scene for game over in the GameManager script with playing the sounds etc etc
        //2. we can have each scene have its own scenemanager function and head from there.
        //Personally I think how it is currently is fine and that we just need to program the menu buttons to lead to different scenes
        SceneManager.LoadScene("Game Over");
        //set points to zero
        
    }
    
    
}
