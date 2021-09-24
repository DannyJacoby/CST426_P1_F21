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

    bool transInvoked = false;
    bool levelInvoked = false;

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
        sceneChange.Invoke();//Tell Game Manager About a Scene Change

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