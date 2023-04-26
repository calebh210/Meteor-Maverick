using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorvetteGunController : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Missile")
        {
            FindObjectOfType<GameManager>().LoadNextLevel();
        }
    }
}
