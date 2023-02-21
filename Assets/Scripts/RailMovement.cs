using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RailMovement : MonoBehaviour
{
    public float speed = 1;


    public Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(0, 0, 0.05f * speed);
        


        //Handler for the boosting/braking

        if (Input.GetKeyDown("space"))
        {
            BoostZoomOut(true);
        }
        if (Input.GetKeyUp("space"))
        {
            BoostZoomOut(false);
        }
        if (Input.GetKeyDown("c"))
        {
            BrakeZoomIn(true);
        }
        if (Input.GetKeyUp("c"))
        {
            BrakeZoomIn(false);
        }
    }

    public void BrakeZoomIn(bool status)
    {
        if (status)
        {
            cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, 35, 0.5f);
            //cam.fieldOfView = 110f;
            setSpeed(0.25f);
        }
        else
        {
            cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, 60, 0.5f);
            //cam.fieldOfView = 60f;
            setSpeed(1f);
        }
    }

    public void BoostZoomOut(bool status)
    {
        if (status)
        {
            cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, 110, 0.5f);
            //cam.fieldOfView = 110f;
            setSpeed(3f);
        }
        else
        {
            cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, 60, 0.5f);
            //cam.fieldOfView = 60f;
            setSpeed(1f);
        }


    }

    void setSpeed(float newSpeed)
    {
        speed = newSpeed;
    }
}
