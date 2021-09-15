using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject fish;//what will be spawned 
    bool canSpawnn = true; //control timer to spawn 
    string[] colors = //color materials available 
   {
        "red",
        "blue",
        "yellow",
        "black"
    };
    void Spawn()
   {
       var temp = Instantiate(fish, transform.position, transform.rotation);
        //change the material to a random color from our color list
       Renderer rend = temp.transform.GetChild(0).transform.GetComponent<Renderer>();
        rend.material = Resources.Load<Material>(colors[Random.Range(0, colors.Length)]);
    }
    //Spawn more fish on a timer 
   IEnumerator NewFish()
    {
        canSpawnn = false;
        Spawn();
        yield return new WaitForSeconds(5f);
        canSpawnn = true;

    }
    private void Update()
    {
        if(canSpawnn)
            StartCoroutine(NewFish());

    }

}
