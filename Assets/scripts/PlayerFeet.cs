using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFeet : MonoBehaviour
{
    public AudioClip[] feetSounds;

    private AudioSource source;
    void Start()
    {
        source = GetComponent<AudioSource>();  
    }

    // Update is called once per frame
    void Footstep()
    {
        AudioClip clip = feetSounds[(int)Random.Range(0,feetSounds.Length)];
        source.clip = clip;
        source.Play();
        Debug.Log(clip.name);
    }
}
