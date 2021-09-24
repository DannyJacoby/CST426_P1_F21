using System.Collections.Generic;
using UnityEngine;



public class GameManager : MonoBehaviour
{
    Generator LevelGenerator = null;
    ScneManager SceneManager = null;

    FXManager FX = null;
    Player player = null;



    string prevScene = null;

    List<string> targets;

    List<string> lastFour;

     int cap = 4;
     float displacement = 4f;



    bool showLevel = false;

    private void Awake()
    {
        LevelGenerator = null;

        FX = GetComponent<FXManager>();
        SceneManager = GameObject.Find("SceneManager").GetComponent<ScneManager>();
        SceneManager.sceneChange.AddListener(delegate { updatePrevScene(); });//Keep Track of Scene Changes
        SceneManager.inTransitionScene.AddListener(delegate { startTransition(); });
        SceneManager.inLevelScene.AddListener(delegate { startLevel(); });
        SceneManager.inEndScene.AddListener(delegate { endLevel(); });
        DontDestroyOnLoad(this.gameObject);

    }

    void startTransition()
    {
        
        LevelGenerator = GameObject.Find("LevelGenerator").GetComponent<Generator>();
        LevelGenerator.atCenter.AddListener(delegate { leaveTransition(); });
        if (prevScene == "WelcomeScreen")
        {
            LevelGenerator.generateNewList(cap,displacement);
            targets = new List<string>(LevelGenerator.getList());
            print("NEWLIST");
            
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
        player.lost.AddListener(delegate { readyEndScene(); });
        player.hitFish.AddListener(delegate { FX.spawnBubble(player.GetComponentInChildren<DrawLine>().target); });
        player.setfishList(targets);
    }
    void readyEndScene()
    {
        lastFour = new List<string>(player.getLastFour());
        SceneManager.loadEndScene();
    }
    void endLevel()
    {

        LevelGenerator = GameObject.Find("LevelGenerator").GetComponent<Generator>();
        LevelGenerator.atCenter.AddListener(delegate { leaveTransition(); });
        LevelGenerator.addToList(lastFour, 0, displacement);
        showLevel = true;

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
        if(SceneManager.currentScene() == "EndScene")
        {
            //avoid duplicates when loading menu
            Destroy(GameObject.Find("GameManager"));
        }
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