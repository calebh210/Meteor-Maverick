using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{

    public float currentHealth = 100f;

    public GameObject crashingFX;
    public GameObject impactFX;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(float damageTaken)
    {
       
     
           currentHealth += damageTaken;

           if (currentHealth <= 0)
           {
            
                if (gameObject.tag == "EnemyShip")
                {
                    gameObject.GetComponent<Rigidbody>().useGravity = true;
                    Instantiate(crashingFX, transform);
                }
           } 

    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Terrain")
        {
            GameObject impact = Instantiate(impactFX, transform.position, transform.rotation);
            Destroy(gameObject);
            Destroy(impact, 1);
        }
    }
}
