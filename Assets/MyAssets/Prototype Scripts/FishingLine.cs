using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FishingLine : MonoBehaviour
{
    public Vector3 target;//fishing line target
    LineRenderer line;

    static public int nextAmount = 4;//initial amount when starting game

    List<string> fishList = LevelGenerator.fishList;//get fish list from LevelGeneartor

    private void Awake()
    {
        line = GetComponent<LineRenderer>();
        nextAmount = fishList.Capacity + 4;//we update the list by four each time // returning nullreferenceexception
       
    }

    private void Update()
    {
        //player input 
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
        if (Input.GetMouseButtonUp(0))
        {
            line.enabled = false;//unrender line 
        }
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
        }
        //check if where we click theres a fish 
        if(Physics.Raycast(ray, out RaycastHit hit)){
            if (hit.transform.CompareTag("Fish"))
            {

                string caught = hit.transform.GetComponent<Renderer>().material.name.ToString();
                print(caught);
                string[] input = caught.Split();
                //compare said fish to our target list in order
                if (input[0].CompareTo(fishList[index])==0)
                {
                    print("MATCH!");
                    index++;
                    Destroy(hit.transform.gameObject);
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

}
