using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{

    //Define the player object to aim at;
    Transform player;
    public float currentHealth = 100f;

    public GameObject crashingFX;
    public GameObject impactFX;

    //fields for shooting at player
    public Transform enemyFirePoint;
    [SerializeField]
    GameObject missile;
    float fireRate;
    float nextFire;
    void Start()
    {
        fireRate = 5f;
        nextFire = Time.time;
        player = GameObject.Find("PlayerCamParent/Player/PlayerModel").transform;
        //enemyFirePoint = this.gameObject.transform.GetChild(6);
    }

    // Update is called once per frame
    void Update()
    {
        //This checks if the player is "in range" of the enemy - using absolute value to make negatives easier
        if (Mathf.Abs(player.position.z) - Mathf.Abs(transform.position.z) <= 200)
        {
            FireGun();
        }
    }

    void FireGun()
    {
        if(Time.time > nextFire && currentHealth > 0)
        {
            enemyFirePoint.LookAt(player);
            Instantiate(missile, enemyFirePoint.position, enemyFirePoint.rotation);
            nextFire = Time.time + fireRate;
            
        }
    }

    public void TakeDamage(float damageTaken)
    {
       
     
           currentHealth += damageTaken;

           if (currentHealth <= 0)
           {
            
                if (gameObject.tag == "Enemy")
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
