using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hoverScript : MonoBehaviour
{
    [SerializeField] private AudioSource audio;

    public void play() {
        audio.Play();
            }
}
