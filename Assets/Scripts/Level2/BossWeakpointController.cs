using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossWeakpointController : MonoBehaviour
{
    float health = 100f;

    public void takeDamage(float damage)
    {
        health += damage;

        if(health <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    public float getHealth()
    {
        return health;
    }

    private void OnCollisionEnter(Collision collision)
    {
       
    }
}
