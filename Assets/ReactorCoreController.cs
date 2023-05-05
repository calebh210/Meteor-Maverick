using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReactorCoreController : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Missile")
        {
            FindObjectOfType<GameManager>().LoadNextLevel();
            Debug.Log("Zarek Defeated");
        }
    }
}
