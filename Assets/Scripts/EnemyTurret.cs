using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTurret : MonoBehaviour
{

    public float currentHealth = 100f;
    //fields for shooting at player
    public Transform enemyFirePoint;
    [SerializeField]
    GameObject missile;
    public GameObject explosionFX;
    float fireRate = 10f;
    float nextFire = 0.0f;
    void Start()
    {
        //enemyFirePoint = gameObject.transform.GetChild(0);
    }

    // Update is called once per frame
    void Update()
    {
        FireGun();
    }

    void FireGun()
    {
        if (Time.time > nextFire && currentHealth > 0)
        {
            enemyFirePoint.LookAt(GameObject.Find("PlayerCamParent/Player/PlayerModel").transform);
            Instantiate(missile, enemyFirePoint.position, enemyFirePoint.rotation);
            nextFire = Time.time + fireRate;
        }
    }

    public void TakeDamage(float damage)
    {
        currentHealth += damage; 

        if(currentHealth <= 0)
        {
            GameObject explosion = Instantiate(explosionFX, transform.position, transform.rotation);
            Destroy(gameObject);
            Destroy(explosion,3);
        }
    }

}
