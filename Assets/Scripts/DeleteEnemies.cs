using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DeleteEnemies : MonoBehaviour
{
    float fleetHealth = 100f;
    public customFloatEvent fleetTakesDamage;
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            Debug.Log("Enemy Entered");
            Destroy(collision.gameObject);
            fleetHealth += -10;
            fleetTakesDamage.Invoke(fleetHealth);
            

        }

        if(fleetHealth <= 0)
        {
            //Add some dialogue about failing here
            FindObjectOfType<GameManager>().EndGame();
        }
    }
}
