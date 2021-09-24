using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlManager : MonoBehaviour
{
    DrawLine line = null;
    Player player;

    private void Awake()
    {
        line = GetComponentInChildren<DrawLine>();
        player = GetComponent<Player>();
    }

    private void Update()
    {
        if (Input.GetAxisRaw("Fire1") != 0)
        {
            line.Draw();
            player.fish();
        }
    }

}
