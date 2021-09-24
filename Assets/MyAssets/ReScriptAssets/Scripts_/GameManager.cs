using System.Collections.Generic;
using UnityEngine;



public class GameManager : MonoBehaviour
{
    Generator LevelGenerator = null;
    ScneManager SceneManager = null;
    Player player = null;

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
        SceneManager.inLevelScene.AddListener(delegate { startLevel(); });
        DontDestroyOnLoad(this.gameObject);
    }

    void startTransition()
    {
        
        LevelGenerator = GameObject.Find("LevelGenerator").GetComponent<Generator>();
        LevelGenerator.atCenter.AddListener(delegate { leaveTransition(); });
        if (prevScene == "WelcomeScreen")
        {
            LevelGenerator.generateNewList(cap,displacement);
            targets = LevelGenerator.getList();
            
        }
        else
        {
            
            LevelGenerator.addToList(targets, 1, displacement);
            targets = new List<string>(LevelGenerator.getList());
            
        }
        showLevel = true;
    }
    void startLevel()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        player.won.AddListener(delegate { SceneManager.loadNextScene(); });
        player.setfishList(targets);
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