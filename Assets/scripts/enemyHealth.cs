using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyHealth : MonoBehaviour
{
    public float health;
    public float maxHealth;

    public GameObject essense;
    void Start()
    {
        health = maxHealth;
    }


    public void damage(int damage)
    {
        health -= damage;

        if (health < 0)
        {
            gameObject.SetActive(false);



            Instantiate(essense, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }

    }
}
