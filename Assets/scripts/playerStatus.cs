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

    public GameObject healthSoundMaker;

    public bool touchingAlter;


    public healthBar healthBarScript;

    private weapon weaponParent;
    private Vector2 pointerInput;

    public deathScreen deathscreen;

    public GameObject alterText;


    public int totalEssenseCount;
    public int currentEssenceCount;

    public timeScript timeScript;

    public GameObject mysprite;
    public Animator animator;

    public DeathSound deathSound;

    public bool stopped;
    [SerializeField] private AudioSource audio;


    // Start is called before the first frame update

    private void Awake()
    {
        //updates values
        currentEssenceCount = PlayerPrefs.GetInt("currentEssenceCount", 0);
        totalEssenseCount = PlayerPrefs.GetInt("totalEssenseCount", 0);
        health = PlayerPrefs.GetInt("health", 100);
        corruption = PlayerPrefs.GetInt("corruption", 0);



        healthBarScript.setCorruption(corruption);
        healthBarScript.SetHealth(health);
        healthBarScript.SetEssence(currentEssenceCount);

        healthBarScript.SetMaxHealth(maxHealth);

        weaponParent = GetComponentInChildren<weapon>();

        stopped = false;
        

        touchingAlter = false;

        transform.position = new Vector3(51f, 11.5f, 0f);
    }

    void Start()
    {
        //PlayerPrefs.DeleteAll();
    }


    // Update is called once per frame
    void Update()
    {

        if (stopped != true)
        {



            if (animator != null)
            {
                if (Input.GetKeyDown("a"))
                {
                    animator.SetBool("isWalkingLeft", true);
                    animator.SetBool("isWalkingRight", false);
                    animator.SetBool("isWalkingDown", false);
                    animator.SetBool("isWalkingUp", false);
                    weaponParent.playerOrientation = "left";
                }
                if (Input.GetKeyDown("d"))
                {
                    animator.SetBool("isWalkingRight", true);

                    animator.SetBool("isWalkingLeft", false);
                    animator.SetBool("isWalkingDown", false);
                    animator.SetBool("isWalkingUp", false);

                    weaponParent.playerOrientation = "right";
                }


                if (Input.GetKeyDown("s"))
                {
                    animator.SetBool("isWalkingDown", true);

                    animator.SetBool("isWalkingLeft", false);
                    animator.SetBool("isWalkingUp", false);
                    animator.SetBool("isWalkingRight", false);

                    weaponParent.playerOrientation = "down";
                }

                if (Input.GetKeyDown("w"))
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

                if (Input.GetKeyUp("d"))
                {
                    animator.SetBool("isWalkingRight", false);
                }

                if (Input.GetKeyUp("s"))
                {
                    animator.SetBool("isWalkingDown", false);
                }

                if (Input.GetKeyUp("w"))
                {
                    animator.SetBool("isWalkingUp", false);
                }

                if (Input.GetKeyUp("h"))
                {
                    Debug.Log("h pressed");
                    if (currentEssenceCount >= 5) //pay 5 essense for health
                    {
                        Debug.Log("healed");
                        health += 15;


                        if (health > 100) //caps health to 100
                        {
                            health -= (health - 100);
                        }

                        healthBarScript.SetHealth(health);

                        currentEssenceCount -= 5;
                        healthBarScript.SetEssence(currentEssenceCount);

                        healthSoundMaker.GetComponent<healthSound>().playSound();
                    
                    }

                }
            }


            if (touchingAlter)
            {
                Debug.Log("touching alter");

                alterText.SetActive(true);
                for (int i = currentEssenceCount; i > 0; i--)
                {
                    corruption++;
                    currentEssenceCount--;

                    healthBarScript.setCorruption(corruption);
                    healthBarScript.SetEssence(currentEssenceCount);
                }

                

            }
            else //if not touching alter
            {
                if(alterText != null)
                {
                    alterText.SetActive(false);
                }
                
            }

        }
        else
        {

        
            gameObject.SetActive(false);
        }
    }

    public void wipeData()
    {
        PlayerPrefs.DeleteAll();
    }

    public void saveValues()
    {
        //refresh 30 hit ponts to health
            health += 30f;

            if(health > 100) //caps health to 100
            {
                health -= (health - 100);
            }

            PlayerPrefs.SetInt("currentEssenceCount", currentEssenceCount);
            PlayerPrefs.SetInt("totalEssenseCount", totalEssenseCount);
            PlayerPrefs.SetFloat("health", health);
            PlayerPrefs.SetInt("corruption", corruption);

            PlayerPrefs.Save();
            gameObject.SetActive(false);
            Destroy(gameObject);
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

            deathSound.playSound();

            deathscreen.playerDeath(totalEssenseCount, timeScript.getDayCount()); //this displays the death death screen
            alterText.SetActive(false);


            timeScript.timerOff(); //pauses the timer


            weaponParent.doesExist = false;

            PlayerPrefs.DeleteAll();

            Destroy(mysprite);
        }
    }

    public int getCorruption()
    {
        return corruption;
    }

    private void OnCollisionStay2D(Collision2D other)
    {

        if (other.gameObject.tag == "deer") //if touched deer
        {
            Debug.Log("TOUCHED DEER");
            takeDamage(0.2f);
        }

        if (other.gameObject.tag == "fox") //if touched fox
        {
            takeDamage(0.4f);
        }

        if (other.gameObject.tag == "bear") //if touched bear
        {
            takeDamage(1f);
        }

        if (other.gameObject.tag == "essense") //if picked up essense
        {
            currentEssenceCount += 1;
            totalEssenseCount += 1;

            Destroy(other.gameObject);

            Debug.Log("essense +1");

            healthBarScript.SetEssence(currentEssenceCount);

            audio.Play();
        }

    }


  


}

