using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using System;

public class ScneManager : MonoBehaviour
{
    string prevScene = null;

    public UnityEvent sceneChange;
    public UnityEvent inTransitionScene;
    public UnityEvent inLevelScene;
    public UnityEvent inEndScene;

    bool transInvoked = false;
    bool levelInvoked = false;
    bool endInvoked = false;



    public void loadNextScene()
    {
        
        prevScene = SceneManager.GetActiveScene().name;
        if (SceneManager.GetActiveScene().name == "Transition")
        {
            levelInvoked = false;
            print("Loading FishingLevel");
            SceneManager.LoadScene("FishingLevel");
       
        }
        if (SceneManager.GetActiveScene().name == "WelcomeScreen")
        {
            transInvoked = false;
            SceneManager.LoadScene("Transition");
            print("Loading Transition");
        }
        if (SceneManager.GetActiveScene().name == "FishingLevel")
        {
            transInvoked = false;
            SceneManager.LoadScene("Transition");
            print("Loading Transition");
        }
        if (SceneManager.GetActiveScene().name == "EndScene")
        {
            transInvoked = false;
            SceneManager.LoadScene("WelcomeScreen");
            print("Loading WelcomeScreen");
            //Destroy to avoid duplicates
            Destroy(transform.gameObject);
        }
        sceneChange.Invoke();//Tell Game Manager About a Scene Change

    }
    public void loadEndScene()
    {
        endInvoked = false;
        SceneManager.LoadScene("EndScene");
        print("Loading End");

    }
    public string getPreviousScene()
    {
        return prevScene;
    }
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
    public void ExitGame()
    {
        print("Quitting Application");
        Application.Quit();
    }
    public string currentScene()
    {
        return SceneManager.GetActiveScene().name;
    }

    public void Update()
    {
        if (SceneManager.GetActiveScene().name == "Transition" && !transInvoked)
        {
            inTransitionScene.Invoke();
            transInvoked = true;

        }
        if(SceneManager.GetActiveScene().name == "FishingLevel" && !levelInvoked)
        {
            inLevelScene.Invoke();
            levelInvoked = true;

        }
        if (SceneManager.GetActiveScene().name == "EndScene" && !endInvoked)
        {
            inEndScene.Invoke();
            endInvoked = true;

        }
    }

}


/*
 * class ScneManager{
 * 
 *string prevScene = null;
 * 
 * public LoadNext();
 * public getPrevScene();
 * public ExitGame();
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 */