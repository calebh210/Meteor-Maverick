using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAttacks : MonoBehaviour
{

    public float fireRate = 0.15F;
    private float nextFire = 0.0F;
    private int missileCount = 300;

    //Making the missile and bullet objects
    public GameObject missile;
    public GameObject laser;
    Camera cam;
    //
    private Transform FirePoint;
    public GameObject farCrossCanvas;


    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        FirePoint = this.gameObject.transform.GetChild(1);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            Instantiate(laser, FirePoint.position, FirePoint.rotation);
            nextFire = Time.time + fireRate;
        }

        if (Input.GetButtonDown("Fire2") && missileCount > 0)
        {
            Instantiate(missile, FirePoint.position, FirePoint.rotation);
            missileCount--;

        }

        crosshairLockOn();
    }

    void crosshairLockOn()
    {
        RaycastHit hit;

        //Making a layercast to ignore the "IgnoreRaycast layer and HitPlane layer
        //If the layercast wasnt there, it the ray would collide with the player or the hitplane
        int mask1 = 1 << LayerMask.NameToLayer("Ignore Raycast");
        int mask2 = 1 << LayerMask.NameToLayer("HitPlane");
        int mask = mask1 | mask2;


        //Shoots a raycast in the direction of the far crosshair relative to the screen
        Ray ray = cam.ScreenPointToRay(farCrossCanvas.GetComponent<RectTransform>().position);
        if (Physics.Raycast(ray, out hit, 200, ~mask))
        {

            Debug.DrawLine(ray.origin, hit.point);
            //Debug.Log(hit.transform.tag);



            if (hit.transform.tag == ("Enemy"))
            {
                //lockedOn = true;
                farCrossCanvas.GetComponent<Image>().color = Color.red;
                //lockOnCoordinates = hit.point;
            }
            else if (hit.transform.tag != "Enemy")
            {
                farCrossCanvas.GetComponent<Image>().color = Color.white;
            }

        }
        else //if nothing is hit by the raycast
        {
            farCrossCanvas.GetComponent<Image>().color = Color.white;
        }
    }


}
