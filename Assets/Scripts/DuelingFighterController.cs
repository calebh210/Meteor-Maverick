using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class DuelingFighterController : MonoBehaviour
{

    Transform player;
    //fields for shooting at player
    public Transform enemyFirePoint;
    [SerializeField]
    GameObject missile;
    float fireRate;
    float nextFire;


    private void Start()
    {
        fireRate = 5f;
        nextFire = Time.time;
        player = GameObject.Find("PlayerCamParent/Player/PlayerModel").transform;
    }
    // Update is called once per frame
    void Update()
    {
        transform.LookAt(player);
        FireGun();
    }

    void FireGun()
    {
        if (Time.time > nextFire)
        {
            enemyFirePoint.LookAt(player);
            Instantiate(missile, enemyFirePoint.position, enemyFirePoint.rotation);
            nextFire = Time.time + fireRate;

        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Terrain")
        {
            Destroy(gameObject);
        }
    }
}
