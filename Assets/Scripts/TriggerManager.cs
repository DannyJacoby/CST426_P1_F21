using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerManager : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if( other.tag == "Fish")
          Destroy(other.gameObject);
    }

}
