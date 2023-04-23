using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float currentHealth = 100f;
    public GameObject explosionFX;

    public void TakeDamage(float damageTaken)
    {

        currentHealth += damageTaken;

        if (currentHealth <= 0)
        {
            GameObject boom = Instantiate(explosionFX, transform.position, transform.rotation);
            Destroy(gameObject);
            Destroy(boom, 2);
        }

    }

}
