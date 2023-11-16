using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chase : MonoBehaviour
{
    public GameObject[] player;
    public float speed;

    public float viewDistance;


    private float distance;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectsWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector2.Distance(transform.position, player[0].transform.position); //distance = distance between player and enemy
        Vector2 direction = player[0].transform.position - transform.position;
        direction.Normalize();

        float angle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg; //angle 

        if (distance < viewDistance)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, player[0].transform.position, speed * Time.deltaTime); //moves enemy towards character

            //transform.rotation = Quaternion.Euler(Vector3.forward * angle);    <-- only used for rotating the enemy towards player

        }
    }
}
