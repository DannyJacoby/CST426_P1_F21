using System.Collections.Generic;
using UnityEngine;



public class GameManager : MonoBehaviour
{
    //Generator LevelGenerator = null;
    //ScneManager SceneManager = null;



    //List<string> targets;
    //int cap = 4;
    //float displacement = 4f;

    

    private void Awake()
    {
       // LevelGenerator = GameObject.Find("LevelGenerator").GetComponent<Generator>();
        //SceneManager = GameObject.Find("SceneManager").GetComponent<ScneManager>();
       // DontDestroyOnLoad(this.gameObject);
    }
    private void Start()
    {
        //check if came from Welcome Screen
       // if(SceneManager.getPreviousScene() == null)
       // {
        //    LevelGenerator.generateNewList(cap, displacement);
        //    targets = LevelGenerator.getList();
       // } 
    }
    private void Update()
    {
        //if (LevelGenerator)
       // {
       //     LevelGenerator.moveAccross();
       // }
    }
}
/*
 * class GameManger{
 * 
 * List targets; //targets player needs to get
 * public GameObject LevelGenerator = null;
 * public GameObject SceneManager = null;
 * 
 * 
 * 
 * 
 * 
 */