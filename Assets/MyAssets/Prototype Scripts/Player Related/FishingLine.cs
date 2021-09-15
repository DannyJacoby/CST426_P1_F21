using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FishingLine : MonoBehaviour
{
    public Vector3 target;
    LineRenderer line;

    static public int nextAmount = 4;

    List<string> fishList = LevelGenerator.fishList;//get fish list 

    private void Awake()
    {
        line = GetComponent<LineRenderer>();
        nextAmount = fishList.Capacity + 4;
       
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
        if (Input.GetMouseButtonUp(0))
        {
            line.enabled = false;
        }
    }

    int index = 0;
    void Shoot()
    {
        Plane plane = new Plane(Vector3.back, 0);

        float distance;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (plane.Raycast(ray, out distance))
        {
            target = ray.GetPoint(distance);
      
            line.SetPosition(0, transform.position);
            line.SetPosition(1, target);
            line.enabled = true;
        }
        if(Physics.Raycast(ray, out RaycastHit hit)){
            if (hit.transform.CompareTag("Fish"))
            {
                
                string caught = hit.transform.GetComponent<Renderer>().material.name.ToString();
                string[] input = caught.Split();
                if (input[0].CompareTo(fishList[index])==0)
                {
                    print("MATCH!");
                    index++;
                    Destroy(hit.transform.gameObject);
                    if(index == fishList.Capacity)
                    {
                        StartCoroutine(LoadScene());
                    }
                }
                else
                {
                    print(caught + " Does Not Equal " + fishList[index]);
                }
               
            }
        }
    }
    IEnumerator LoadScene()
    {
        yield return new WaitForSeconds(1);
        Debug.Log("Loading new scene called FishingLevel");
        SceneManager.LoadScene("Transition");
    }

}
