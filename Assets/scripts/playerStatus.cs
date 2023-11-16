using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using CodeMonkey.Utils;

public class playerStatus : MonoBehaviour
{
    public float health;
    public int maxHealth;
    public int corruption;

    public healthBar healthBarScript;

    private weapon weaponParent;
    private Vector2 pointerInput;

    public deathScreen deathscreen;


    public int totalEssenseCount;
    public int currentEssenceCount;

    public timeScript timeScript;

    public GameObject mysprite;
    public Animator animator;


    // Start is called before the first frame update
    void Start()
    {
        corruption = 0;
        healthBarScript.setCorruption(corruption);

        health = maxHealth;
        healthBarScript.SetMaxHealth(maxHealth);

        weaponParent = GetComponentInChildren<weapon>();

    }

    // Update is called once per frame
    void Update()
    {
        if(animator != null)
        {
            if (Input.GetKeyDown("a"))
            {
                animator.SetBool("isWalkingLeft", true);
                animator.SetBool("isWalkingRight", false);
                animator.SetBool("isWalkingDown", false);
                animator.SetBool("isWalkingUp", false);
                weaponParent.playerOrientation = "left";
            }
            else if (Input.GetKeyDown("d"))
            {
                animator.SetBool("isWalkingRight", true);

                animator.SetBool("isWalkingLeft", false);
                animator.SetBool("isWalkingDown", false);
                animator.SetBool("isWalkingUp", false);

                weaponParent.playerOrientation = "right";
            }


            else if (Input.GetKeyDown("s"))
            {
                animator.SetBool("isWalkingDown", true);

                animator.SetBool("isWalkingLeft", false);
                animator.SetBool("isWalkingUp", false);
                animator.SetBool("isWalkingRight", false);

                weaponParent.playerOrientation = "down";
            }

            else if (Input.GetKeyDown("w"))
            {
                animator.SetBool("isWalkingUp", true);

                animator.SetBool("isWalkingLeft", false);
                animator.SetBool("isWalkingDown", false);
                animator.SetBool("isWalkingRight", false);

                weaponParent.playerOrientation = "up";
            }

            //for the release of each button

            if (Input.GetKeyUp("a"))
            {
                animator.SetBool("isWalkingLeft", false);
            }

            else if (Input.GetKeyUp("d"))
            {
                animator.SetBool("isWalkingRight", false);
            }

            else if (Input.GetKeyUp("s"))
            {
                animator.SetBool("isWalkingDown", false);
            }

            else if (Input.GetKeyUp("w"))
            {
                animator.SetBool("isWalkingUp", false);
            }
        }
        
    }




    public void addCorruption(int addedCorruption)
    {
        corruption += addedCorruption;
        healthBarScript.setCorruption(corruption);
    }

    public void takeDamage(float damage)
    {
        health -= damage;
        healthBarScript.SetHealth(health);

        if (health <= 0) //player death
        {
            healthBarScript.SetHealth(0);



            deathscreen.playerDeath(totalEssenseCount, timeScript.getDayCount()); //this displays the death death screen



            timeScript.timerOff(); //pauses the timer



            Destroy(mysprite);
        }
    }



    private void OnCollisionStay2D(Collision2D other)
    {

        if (other.gameObject.tag == "deer") //if touched deer
        {
            Debug.Log("TOUCHED DEER");
            takeDamage(0.5f);
        }

        if (other.gameObject.tag == "fox") //if touched fox
        {
            takeDamage(1f);
        }

        if (other.gameObject.tag == "bear") //if touched bear
        {
            takeDamage(2f);
        }

        if (other.gameObject.tag == "essense") //if picked up essense
        {
            currentEssenceCount += 1;
            totalEssenseCount += 1;

            Destroy(other.gameObject);

            Debug.Log("essense +1");
        }
    }


}

