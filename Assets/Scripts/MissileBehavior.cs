using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Missile asset and license https://sketchfab.com/3d-models/sci-fi-missile-1be9ec86a68d4657920fec178be1626c
public class MissileBehavior : MonoBehaviour
{
    public float damage = -101f;
    public GameObject explosionFX;

    // Start is called before the first frame update
    void Start()
    {
 
        transform.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0, 0, 5000f));
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject missileHit = Instantiate(explosionFX, transform.position, transform.rotation);
        //Debug.Log(collision.gameObject.name);

        if(collision.gameObject.tag == "Enemy")
        {
            EnemyHealth enemy = collision.gameObject.GetComponent<EnemyHealth>();
            enemy.TakeDamage(damage);
        }
        if (collision.gameObject.tag == "EnemyTurret")
        {
            EnemyTurret enemy = collision.gameObject.GetComponent<EnemyTurret>();
            enemy.TakeDamage(damage);
        }

        if(collision.gameObject.tag == "Player")
        {
            Player player = collision.gameObject.GetComponent<Player>();
            player.updateHealth(damage);
        }



        Destroy(gameObject);
        Destroy(missileHit, 1);
    }
}
