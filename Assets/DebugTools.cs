using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DebugTools : MonoBehaviour
{
   
    //This script is for debug tools, and allows any level to be skipped to from the main menu

    // Update is called once per frame
    void Update()
    {

        //skip to level 2
        if (Input.GetKeyDown("2"))
        {
            SceneManager.LoadScene(4);
        }
        //skip to level 3
        if (Input.GetKeyDown("3"))
        {
            SceneManager.LoadScene(6);
        }
        //skip to level 4
        if (Input.GetKeyDown("4"))
        {
            SceneManager.LoadScene(8);
        }
        //skip to level 5
        if (Input.GetKeyDown("5"))
        {
            SceneManager.LoadScene(10);
        }

    }
}
