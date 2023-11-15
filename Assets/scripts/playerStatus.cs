using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class playerStatus : MonoBehaviour
{
    public int health;
    public int maxHealth;
    public int corruption;

    public healthBar healthBarScript;

    //private weapon weaponParent;
    private Vector2 pointerInput;

    //private InputActionReference pointerPosition;

    // Start is called before the first frame update
    void Start()
    {
        corruption = 0;
        healthBarScript.setCorruption(corruption);

        health = maxHealth;
        healthBarScript.SetMaxHealth(maxHealth);

        //weaponParent = GetComponentInChildren<weapon>(); 
        
    }

    // Update is called once per frame
    void Update()
    {
        //pointerInput = GetPointerInput();

        //weapon.PointerPosition = pointerInput;
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
    /*
    private Vector2 GetPointerInput()
    {
        //Vector3 mousePos = pointerPosition.action.ReadValue<Vector2>();
        //mousePos.z = Camera.main.nearClipPlane;
        //return Camera.main.ScreenToWorldPoint(mousePos);
        return null;
    }
    */

}

