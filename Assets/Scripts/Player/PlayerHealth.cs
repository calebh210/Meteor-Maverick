using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerHealth : MonoBehaviour
{
    public customFloatEvent updateUIHealth;
    public float playerHealth = 10000f;

    private void OnCollisionEnter(Collision collision)
    {
        updateHealth(-50f);
    }
    public void updateHealth(float damage)
    {

       playerHealth += damage;

       updateUIHealth.Invoke(playerHealth);


        if (playerHealth <= 0)
        {
            FindObjectOfType<GameManager>().EndGame();
        }
    }

}
