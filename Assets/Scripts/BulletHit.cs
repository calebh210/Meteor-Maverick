using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHit : MonoBehaviour
{

    public float damage = -50f;
    // Start is called before the first frame update
    void Start()
    {
        transform.Rotate(90, 0, 0);
        GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0, 0, 25000f));
        Destroy(gameObject, 5);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
       
        
        if (collision.gameObject.tag == "Enemy")
        {
            EnemyHealth enemy = collision.gameObject.GetComponent<EnemyHealth>();
            enemy.TakeDamage(damage);

        }

        if (collision.gameObject.tag == "EnemyTurret")
        {
            EnemyTurret enemy = collision.gameObject.GetComponent<EnemyTurret>();
            enemy.TakeDamage(damage);

        }

        Destroy(gameObject);
       
    }
}
