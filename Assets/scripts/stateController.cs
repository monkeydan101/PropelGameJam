using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class stateController : MonoBehaviour
{
    public void ReloadCurrentScene() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

         }

    //for changing scenes by name
    public void ChangeSceneByName(string name)
    {
        if(name != null)
        {
            SceneManager.LoadScene(name);
        }
    }
}
