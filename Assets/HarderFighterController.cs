using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HarderFighterController : MonoBehaviour
{
    // Start is called before the first frame update
    Transform player;
    Transform FirePoint;
    public Transform weapon;

    float fireRate = 1f;
    float nextFire = 0f;

    void Start()
    {
        player = GameObject.Find("PlayerCamParent/Player/PlayerModel").transform;
        FirePoint = transform.GetChild(1);
    }


    // Update is called once per frame
    void Update()
    {
        FirePoint.LookAt(player);

        if(Time.time > nextFire)
        {
            Instantiate(weapon, FirePoint.position, FirePoint.rotation);
            nextFire = Time.time + fireRate;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
}
