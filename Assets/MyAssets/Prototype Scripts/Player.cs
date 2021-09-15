using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    GameObject Rod;

    private void Awake()
    {
        Rod = transform.GetChild(0).gameObject;
    }
  
}
