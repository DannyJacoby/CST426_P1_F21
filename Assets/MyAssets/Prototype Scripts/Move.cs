using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
   float speed = 5f;
    

    // Update is called once per frame
    void Update()
    {
     
     transform.Translate(speed * Time.deltaTime, 0, 0, Space.Self);
      
    }
}
