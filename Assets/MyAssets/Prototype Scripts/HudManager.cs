using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HudManager : MonoBehaviour
{
    [SerializeField] GameObject informer;
    FishingLine data;

    TextMeshProUGUI progress;
    
    
    void Awake()
    {

        progress = transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        data = informer.GetComponent<FishingLine>();
       
    }
    private void FixedUpdate()
    {
         progress.text = "Fishes Caught: " + data.fishCaught().ToString() + " / " + data.fishNeeded().ToString();
    }
}
