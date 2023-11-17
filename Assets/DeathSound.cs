using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathSound : MonoBehaviour
{
    [SerializeField] private AudioSource audio;
    // Start is called before the first frame update
    public void playSound()
    {
        audio.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
