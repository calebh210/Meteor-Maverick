using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitByMissile : MonoBehaviour
{
    public float damage = -101f;
    public GameObject explosionFX;

    // Start is called before the first frame update
    void Start()
    {
        transform.Rotate(90, 0, 0);
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
        if(collision.gameObject.tag == "EnemyShip")
        {
            EnemyHealth enemy = collision.gameObject.GetComponent<EnemyHealth>();
            enemy.TakeDamage(damage);
            
        }
        Destroy(gameObject);
        Destroy(missileHit, 1);
    }
}
