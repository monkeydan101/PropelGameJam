using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathSound : MonoBehaviour
{

    private bool hasPlayed;
    [SerializeField] private AudioSource audio;
    // Start is called before the first frame update
    public void playSound()
    {
        if(hasPlayed != true)
        {
            audio.Play();
            hasPlayed = true;
        }
      
    }

    // Update is called once per frame
    void Start()
    {
        hasPlayed = false;
    }
}
