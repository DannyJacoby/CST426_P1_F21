using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FXManager : MonoBehaviour
{
    ParticleSystem bubbles;

    List<AudioClip> sounds;
    List<string> sIndex;
    AudioSource source;
    private void Awake()
    {
        source = GetComponent<AudioSource>();
        sIndex = new List<string>();
        sounds = new List<AudioClip>();
        bubbles = Resources.Load<ParticleSystem>("Particle_Bubble");
        foreach (AudioClip s in Resources.LoadAll("Sounds", typeof(AudioClip)))
        {
            sounds.Add(s);
            sIndex.Add(s.name);
        }
    }

    public void spawnBubble(Vector3 target)
    {
        Instantiate(bubbles, target, Quaternion.identity);
        playSound("pop",.05f);
    }

    public void playSound(string clip,float amps)
    {
        int i = sIndex.IndexOf(clip);
        AudioSource.PlayClipAtPoint(sounds[i], Camera.main.transform.position, .05f);
    }
    public void click()
    {
        playSound("click",.05f);
    }



}
