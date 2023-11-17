using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class exitHouseScript : MonoBehaviour
{
    public housePlayer player;
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("exit");
        player.hasExited = true;
     
    }

}

