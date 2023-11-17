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

    private void Awake()
    {
        //DontDestroyOnLoad(gameObject);
    }
    public void damage(float damage)
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
