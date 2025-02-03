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
    public event Action death;
    //The same logic goes here for when you win & when you point gain
    public event Action win;
    public event Action pointchange;

    [SerializeField]
    private int currentpoints;
    [SerializeField]
    public int startingpoints = 0;
    
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
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //here the game is just setup to take you to the main menu on start
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void MainMenu()
    {
        SceneManager.LoadScene("Starting screen");

    }

    void OnScoreChange(int points)
    {
        //Set up to increments points any function that would deal with chaning your points would go through here
        // for example if you needed to make it so that taking dmg reduces score your 
        currentpoints += points;
        pointchange?.Invoke();
    }

    void UpdateScore()
    {
        //Saving score in player prefs could work 
    }

    public void OnDeath()
    {
        //this is where the death processes are handled when someone invokes the on death event
        
        //From here ther are two choices on how to handle coding the moving parts
        //1. we can have it do the scene for game over in the GameManager script with playing the sounds etc etc
        //2. we can have each scene have its own scenemanager function and head from there.
        //Personally I think how it is currently is fine and that we just need to program the menu buttons to lead to different scenes
        SceneManager.LoadScene("Game Over");
        //set points to zero
        
        death?.Invoke();
    }
    
    
}
