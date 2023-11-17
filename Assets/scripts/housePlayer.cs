using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using CodeMonkey.Utils;

public class housePlayer : MonoBehaviour
{
    

    public GameObject mysprite;
    public Animator animator;

    public bool hasExited;

    // Start is called before the first frame update
    void Start()
    {

        hasExited = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (animator != null)
        {
            if (Input.GetKeyDown("a"))
            {
                animator.SetBool("isWalkingLeft", true);
                animator.SetBool("isWalkingRight", false);
                animator.SetBool("isWalkingDown", false);
                animator.SetBool("isWalkingUp", false);
                
            }
            else if (Input.GetKeyDown("d"))
            {
                animator.SetBool("isWalkingRight", true);

                animator.SetBool("isWalkingLeft", false);
                animator.SetBool("isWalkingDown", false);
                animator.SetBool("isWalkingUp", false);

                
            }


            else if (Input.GetKeyDown("s"))
            {
                animator.SetBool("isWalkingDown", true);

                animator.SetBool("isWalkingLeft", false);
                animator.SetBool("isWalkingUp", false);
                animator.SetBool("isWalkingRight", false);

               
            }

            else if (Input.GetKeyDown("w"))
            {
                animator.SetBool("isWalkingUp", true);

                animator.SetBool("isWalkingLeft", false);
                animator.SetBool("isWalkingDown", false);
                animator.SetBool("isWalkingRight", false);

                
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

        if (hasExited)
        {
            ReloadCurrentScene();



            SceneManager.LoadScene("main");
        }


    }

    public void ReloadCurrentScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }

    //for changing scenes by name
    public void ChangeSceneByName(string name)
    {
        if (name != null)
        {
            SceneManager.LoadScene(name);
        }
    }





}

