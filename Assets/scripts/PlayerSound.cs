using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSound : MonoBehaviour
{
    public AudioClip[] swingSounds;

    private AudioSource source;
    void Start()
    {
        source = GetComponent<AudioSource>();  
    }

    // Update is called once per frame
    void PlayScytheSwing()
    {
        AudioClip clip = swingSounds[(int)Random.Range(0,swingSounds.Length)];
        source.clip = clip;
        source.Play();
        Debug.Log(clip.name);
    }
}
