using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flipRules : MonoBehaviour
{
    public bool isActive;
    // Start is called before the first frame update
    void Start()
    {
        isActive = false;
    }

    public void flip()
    {
        if (isActive)
        {
            gameObject.SetActive(false);
            isActive = false;
        }
        else
        {
            gameObject.SetActive(true);
            isActive = true;
        }
    }
}
