using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{

    public float currentHealth = 100f;

    public GameObject crashingFX;
    public GameObject impactFX;

    //fields for shooting at player
    Transform enemyFirePoint;
    [SerializeField]
    GameObject missile;
    float fireRate;
    float nextFire;
    void Start()
    {
        fireRate = 1f;
        nextFire = Time.time;
        enemyFirePoint = this.gameObject.transform.GetChild(6);
    }

    // Update is called once per frame
    void Update()
    {
        FireGun();
    }

    void FireGun()
    {
        if(Time.time > nextFire && currentHealth > 0)
        {
            enemyFirePoint.LookAt(GameObject.Find("PlayerCamParent/Player/PlayerModel").transform);
            Instantiate(missile, enemyFirePoint.position, enemyFirePoint.rotation);
            nextFire = Time.time + fireRate;
        }
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
