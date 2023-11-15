using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using CodeMonkey.Utils;

public class playerStatus : MonoBehaviour
{
    public int health;
    public int maxHealth;
    public int corruption;

    public healthBar healthBarScript;

   

    public Animator animator;


    private weapon weaponParent;
    private Vector2 pointerInput;


    //private InputActionReference pointerPosition;

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



        //for RELEASE OF EACH BUTTON:


        
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

    void addCorruption(int addedCorruption)
    {
        corruption += addedCorruption;
        healthBarScript.setCorruption(corruption);
    }

    void takeDamage(int damage)
    {
        health -= damage;
        healthBarScript.SetHealth(health);

        if (health <= 0) //player death
        {

        }
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        Debug.Log("TOUCHED SMTH");
        if (other.gameObject.tag == "deer") //if touched deer
        {
            Debug.Log("TOUCHED DEER");
            takeDamage(1);
        }

        if (other.gameObject.tag == "fox") //if touched fox
        {

        }

        if (other.gameObject.tag == "bear") //if touched bear
        {

        }
    }  
 

}

