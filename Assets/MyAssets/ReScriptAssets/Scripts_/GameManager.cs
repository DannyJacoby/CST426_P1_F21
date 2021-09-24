using System.Collections.Generic;
using UnityEngine;



public class GameManager : MonoBehaviour
{
    Generator LevelGenerator = null;
    ScneManager SceneManager = null;

    string prevScene = null;

     List<string> targets;
     int cap = 4;
     float displacement = 4f;



    bool showLevel = false;

    private void Awake()
    {
        LevelGenerator = null;
        // LevelGenerator = GameObject.Find("LevelGenerator").GetComponent<Generator>();
      
        SceneManager = GameObject.Find("SceneManager").GetComponent<ScneManager>();
        SceneManager.sceneChange.AddListener(delegate { updatePrevScene(); });//Keep Track of Scene Changes
        SceneManager.inTransitionScene.AddListener(delegate { startTransition(); });
        DontDestroyOnLoad(this.gameObject);
    }

    void startTransition()
    {
        if(prevScene == "WelcomeScreen")
        {
            LevelGenerator = GameObject.Find("LevelGenerator").GetComponent<Generator>();
            LevelGenerator.atCenter.AddListener(delegate { leaveTransition(); });
            LevelGenerator.generateNewList(cap,displacement);
            targets = LevelGenerator.getList();
            showLevel = true;

        }
    }
    private void updatePrevScene()
    {
        
        prevScene = SceneManager.getPreviousScene();
    }
    private void Update()
    {
        if (showLevel) LevelGenerator.moveAccross();
    }
    void leaveTransition()
    {
        showLevel = false;
        SceneManager.loadNextScene();
    }
}
/*
 * class GameManger{
 * 
 * List targets; //targets player needs to get
 * 
 * public GameObject SceneManager = null;
 * 
 * string prevScene;
 * 
 * 
 * 
 * 
 * 
 */