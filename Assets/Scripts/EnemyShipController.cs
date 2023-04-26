using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShipController : MonoBehaviour
{
    //Define the player object to aim at;
    Transform player;
    public float currentHealth = 100f;

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
        if (Time.time > nextFire && currentHealth > 0)
        {
            enemyFirePoint.LookAt(player);
            Instantiate(missile, enemyFirePoint.position, enemyFirePoint.rotation);
            nextFire = Time.time + fireRate;

        }
    }

}
