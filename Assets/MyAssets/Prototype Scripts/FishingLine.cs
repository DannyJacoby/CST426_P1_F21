using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FishingLine : MonoBehaviour
{
    public Vector3 target;//fishing line target
    LineRenderer line;

    public GameObject particles;
    static public int nextAmount = 4;//initial amount when starting game

    List<string> fishList = LevelGenerator.fishList;


    private void Awake()
    {
        
        line = GetComponent<LineRenderer>();
        if (fishList == null)
        {//for testing purposes
            fishList = new List<string>(4);
            fishList.Add("blue");
            fishList.Add("blue");
            fishList.Add("blue");
            fishList.Add("blue");
        }
        nextAmount = fishList.Capacity + 1;


    }

    private void Update()
    {
        //player input 
        if (Input.GetAxisRaw("Fire1") != 0)
        {
            Shoot();
        }
        if (Input.GetAxisRaw("Fire1") == 0)
        {
            line.enabled = false;//unrender line 
        }
        if (Input.GetKey("escape")) Application.Quit();
    }

    int index = 0;
    void Shoot()
    {
        Plane plane = new Plane(Vector3.back, 0);//used to calcualte world space coordinates

        float distance;
        //calculate our target end drawing vertex
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (plane.Raycast(ray, out distance))
        {
            target = ray.GetPoint(distance);
      
            line.SetPosition(0, transform.position);
            line.SetPosition(1, target);
            line.enabled = true;
            //Instantiate(particles, target, Quaternion.identity);
        }
        //check if where we click theres a fish 
        if(Physics.Raycast(ray, out RaycastHit hit)){
            if (hit.transform.CompareTag("Fish"))
            {
                Instantiate(particles, target, Quaternion.identity);
                Destroy(hit.transform.gameObject);
                string caught = hit.transform.GetComponent<Renderer>().material.name.ToString();
                string[] input = caught.Split();
                //compare said fish to our target list in order
                if (input[0].CompareTo(fishList[index])==0)
                {
                    print("MATCH!");
                
                    index++;
                    ;
                    if(index == fishList.Capacity)
                    {
                        StartCoroutine(WinScene());
                    }
                }
                //we messed up 
                else
                {
                    //end scene goes somewhere here
                    print(caught + " Does Not Equal " + fishList[index]);

                    SceneManager.LoadScene("EndScene");

                }

            }
        }
    }
    //we load in transition scene if win 
    IEnumerator WinScene()
    {
        yield return new WaitForSeconds(1);
        Debug.Log("Loading new scene called FishingLevel");
        SceneManager.LoadScene("Transition");
    }
    public int fishCaught()
    {
        return index;
    }
    public int fishNeeded()
    {
        return fishList.Capacity;
    }
}
