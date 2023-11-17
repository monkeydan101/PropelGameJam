using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class exitHouseScript : MonoBehaviour
{

    public housePlayer player;
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("exit");
        player.hasExited = true;
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
