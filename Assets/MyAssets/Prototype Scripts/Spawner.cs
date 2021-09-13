using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject fish;
    bool canSpawnn = true;
    string[] colors =
   {
        "red",
        "blue",
        "yellow",
        "black"
    };
    void Spawn()
   {
       var temp = Instantiate(fish, transform.position, transform.rotation);
       Renderer rend = temp.GetComponent<Renderer>();
       rend.material = Resources.Load<Material>(colors[Random.Range(0, colors.Length)]);
    }
    //Spawn more fish on a timer 
   IEnumerator NewFish()
    {
        canSpawnn = false;
        Spawn();
        yield return new WaitForSeconds(2f);
        canSpawnn = true;

    }
    private void Update()
    {
        if(canSpawnn)
            StartCoroutine(NewFish());

    }

}
