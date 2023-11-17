using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wipePlayerPrefs : MonoBehaviour
{
    // Start is called before the first frame update
    public void wipe()
    {
        PlayerPrefs.DeleteAll();
    }
}
