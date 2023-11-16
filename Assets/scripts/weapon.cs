using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;
using System;
using Unity.VisualScripting;

public class weapon : MonoBehaviour
{
    public Vector3 PointerPosition { get; set; }
    public float delay = 0.3f;
    private bool attackBlocked;
    public Transform circleOrigin;
    public float radius;


    private Transform weaponTransform;
    public Animator animator;
    public String playerOrientation;
    private void Awake()
    {
        weaponTransform = transform.Find("weapon");
        playerOrientation = "up";
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            Attack();
        }
    }

    
    private void LateUpdate()
    {
        /*
        Vector3 mousePosition = UtilsClass.GetMouseWorldPosition();

        Vector3 aimDirection = (mousePosition - transform.position).normalized;
        float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
        //pointerInput = new Vector2(Input.mousePosition.x, Input.mousePosition.y);


        weaponTransform.eulerAngles = new Vector3(0, 0, angle - 90);
        */
    }
    

    public void Attack()
    {
        if (attackBlocked)
        {
            return;
        }

        //these if's play an animation depending on the orientation of the player
        if(playerOrientation == "up")
        {
            animator.SetTrigger("AttackUp");
        }
        if (playerOrientation == "down")
        {
            animator.SetTrigger("AttackDown");
        }
        if (playerOrientation == "left")
        {
            animator.SetTrigger("AttackLeft");
        }
        if (playerOrientation == "right")
        {
            animator.SetTrigger("AttackRight");
        }

        


        attackBlocked = true;
        
        Debug.Log("Attacked");
        StartCoroutine(DelayAttack());

    }

    private IEnumerator DelayAttack()
    {
        yield return new WaitForSeconds(delay);
        attackBlocked = false;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Vector3 position = circleOrigin == null ? Vector3.zero : circleOrigin.position;
        Gizmos.DrawWireSphere(position, radius);
    }


    public void DetectColliders()
    {
        foreach (BoxCollider2D collider in Physics2D.OverlapCircleAll(circleOrigin.position, radius))
        {
            if (collider.gameObject.GetComponent<enemyHealth>() != null)
            {
                if (collider.gameObject.tag == "deer" || collider.gameObject.tag == "fox" || collider.gameObject.tag == "bear")
                {
                    collider.gameObject.GetComponent<enemyHealth>().damage(5);
                }
            }
               
            }
        }
    }

