using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HudManager : MonoBehaviour
{
    Player player = null;

    TextMeshProUGUI progress = null;
    
    
    void Awake()
    {

        progress = transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        player = GameObject.Find("Player").GetComponent<Player>();
        
       
    }
   
    public void upDateText()
    {
        progress.text = "Fishes Caught: " + player.currentCount() + " / " + player.totalNeeded();
    }
    public void upDateText(int current, int need)
    {
        progress.text = "Fishes Caught: " + current + " / " + need;

    }

}
