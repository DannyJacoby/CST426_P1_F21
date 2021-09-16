using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject fish;
    bool canSpawnn = true;
    
   void Spawn()
   {
       Instantiate(fish, transform.position, transform.rotation);
    }
    //Spawn more fish on a timer 
   IEnumerator NewFish()
    {
        canSpawnn = false;
        Spawn();
        yield return new WaitForSeconds(4f);
        canSpawnn = true;

    }
    private void Update()
    {
        if(canSpawnn)
            StartCoroutine(NewFish());

    }

}
