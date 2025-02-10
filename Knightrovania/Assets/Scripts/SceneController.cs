using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneController : MonoBehaviour
{
    public static SceneController instance;
    [SerializeField] private Animator transitionAnim;
    private FinishPoint gates;
    
    private void Awake()
    {
        if (instance == null)
        {
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        FinishPoint.onDoorEnter += NextLevel;
    }

    public void NextLevel(int buildIndex)
    {
        StartCoroutine (LoadLevel(buildIndex));
        
    }

    IEnumerator LoadLevel(int buildIndex)
    {
        transitionAnim.SetTrigger("End");
        yield return new WaitForSeconds(1);
        //Investigate
        SceneManager.LoadSceneAsync(buildIndex);
        transitionAnim.SetTrigger("Start");
    }
}