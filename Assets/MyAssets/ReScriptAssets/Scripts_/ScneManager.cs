using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScneManager : MonoBehaviour
{
    string prevScene = null;

    public void loadNextScene()
    {
        prevScene = SceneManager.GetActiveScene().name;
        if (SceneManager.GetActiveScene().name == "Transition")
        {
            print("Loading FishingLevel");
            SceneManager.LoadScene("FishingLevel");
        }
        if (SceneManager.GetActiveScene().name == "WelcomeScreen")
        {
            SceneManager.LoadScene("Transition");
            print("Loading Transition");
        }

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
        Application.Quit();
    }
}
/*
 * class ScneManager{
 * 
 *string prevScene = null;
 * 
 * public LoadNext()
 * public getPrevScene();
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 */