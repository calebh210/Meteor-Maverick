using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossStationController : MonoBehaviour
{
    private float health = 100f;
    public customFloatEvent UpdateUIElement;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Missile")
        {
            UpdateHealth(-5);
        }
    }

    private void UpdateHealth(int damage)
    {
        health += damage;
        UpdateUIElement.Invoke(this.health);

        if(health < 0)
        {
            FindObjectOfType<GameManager>().LoadNextLevel();
        }
    }
}
