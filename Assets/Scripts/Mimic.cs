using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mimic : MonoBehaviour
{

    

    private void Update()
    {
        //Get x coordinate of mouse posistion converege from -1 to 1
        float x = Camera.main.ScreenToViewportPoint(Input.mousePosition).x;
              x = (-2 * x) - 1;

        //Create new z rotation in order to pivot rod
        Quaternion newRotation = Quaternion.Euler(
            transform.rotation.eulerAngles.x,
            transform.rotation.eulerAngles.y,
            90f * x
            ) ;

        transform.rotation = newRotation;
    }


}
