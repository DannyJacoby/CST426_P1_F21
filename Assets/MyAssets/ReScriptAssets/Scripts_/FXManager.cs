using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FXManager : MonoBehaviour
{
    ParticleSystem bubbles;

    private void Awake()
    {
        bubbles = Resources.Load<ParticleSystem>("Particle_Bubble");
    }

    public void spawnBubble(Vector3 target)
    {
        Instantiate(bubbles, target, Quaternion.identity);
    }



}
