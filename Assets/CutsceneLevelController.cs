using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneLevelController : MonoBehaviour
{
    

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Return))
        {
            nextLevel();
        }
    }

    void nextLevel()
    {

        FindObjectOfType<GameManager>().LoadNextLevel();
        Debug.Log("next level");
    }
}
