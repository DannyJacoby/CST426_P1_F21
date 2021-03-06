using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelGenerator : MonoBehaviour
{
    [SerializeField] GameObject fish;//object to spawn 
    Vector3 spawn;//inital spawn location 

    static public int numberOfFish = 4;//how many objects to spawn
    public float speed = 5;//how fast to move into scene

    float displacement = 4f;//how far apart each object will be 
    bool start = false;//delay start moving into frame 

    string[] colors =
    {
        "red",      
        "blue",     
        "yellow",   
        "black"     
    };

    public static List<string> fishList;


    private void Awake()
    {
        //Fishingline script found in the fishing levels scene, If
        //next amount is greater it means we previously won set new
        //amount. if equal we equal its the first time starting game 
        if (FishingLine.nextAmount > numberOfFish)
            numberOfFish = FishingLine.nextAmount;


        //adjust speed dependent on number of fish
        speed -= ((numberOfFish - 1) / speed);

        //scale gameObject to fit all fish
        transform.localScale = new Vector3(numberOfFish * displacement, 1, 1);
        
        //adjust location
        float zeta = numberOfFish;
        transform.position = new Vector3(12 + (displacement * numberOfFish), 0, zeta);
        
        //set spawn locatiom
        spawn = new Vector3(transform.position.x + transform.localScale.x / -2, transform.position.y, transform.position.z);
        spawn.x += displacement / 2;
        
        //generate a random list of colors
        fishList = new List<string>();
        for(int i = 0; i < numberOfFish; i++)
        {
            fishList.Add(colors[Random.Range(0, colors.Length)]);
        }
    }


    private void Start()
    {
        SpawnAllFish();
    }

    //spawn fish and child into LevelGenerator game object inorder to move only
    //one thing into place rather than all the fish
    void SpawnAllFish()
    {
        for (int i = 0; i < numberOfFish; i++)
        {
            var temp = Instantiate(fish, spawn, Quaternion.identity);
            Destroy(temp.GetComponent<Move>()); //take away move behaviour

            //render its color
            Renderer rend = temp.transform.GetChild(0).transform.GetComponent<Renderer>();
            rend.material = Resources.Load<Material>(fishList[i]);

            temp.transform.parent = gameObject.transform;
            spawn.x += displacement;
        }
    }

    
    private void Update()
    {
        if (!start)
        {
            StartCoroutine(Delay());
        }
        else
        {
            //move level generator game object until centered on scene 
            float step = speed * Time.deltaTime; // calculate distance to move
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(0, transform.position.y, transform.position.z), step);
        }

        if (transform.position.x == 0)
        {
            StartCoroutine(LoadGame());
        }
    }


    IEnumerator Delay()
    {
        yield return new WaitForSeconds(.1f * numberOfFish);
        start = true;
    }


    IEnumerator LoadGame()
    {
        yield return new WaitForSeconds(1);
        Debug.Log("Loading new scene called FishingLevel");
        SceneManager.LoadScene("FishingLevel");
    }
}
