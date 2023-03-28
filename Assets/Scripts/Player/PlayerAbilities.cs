using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


[System.Serializable] public class customFloatEvent : UnityEvent<float> { } //Lets me add a float arg to event call;

public class PlayerAbilities : MonoBehaviour
{
    private float abilityTime = 100f;
    float abilityRechargeCooldown = 5.0f;
    float abilityLastUsed = 0.0f;
    Camera cam;
    public customFloatEvent updateUIAbility;

    private void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey("space"))
        {
            BoostZoomOut(true);
        }
        else if (Input.GetKeyUp("space"))
        {
            BoostZoomOut(false);
        }
        if (Input.GetKey("c"))
        {
            BrakeZoomIn(true);
        }
        else if (Input.GetKeyUp("c"))
        {
            BrakeZoomIn(false);
        }

        abilityRecharge();

    }

    public void BrakeZoomIn(bool status)
    {
        if (status && abilityTime > 0)
        {
            cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, 60, 0.5f);
            //cam.fieldOfView = 60;
            gameObject.GetComponentInParent<Cinemachine.CinemachineDollyCart>().m_Speed = 20f;
            abilityTime += -0.25f;
            updateUIAbility.Invoke(abilityTime);
            abilityLastUsed = Time.time;


        }
        else
        {
            cam.fieldOfView = 80;
            //cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, 80, 0.5f);
            gameObject.GetComponentInParent<Cinemachine.CinemachineDollyCart>().m_Speed = 50f;


        }
    }

    public void BoostZoomOut(bool status)
    {
        if (status && abilityTime > 0)
        {
            //cam.fieldOfView = 100;
            cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, 100, 0.5f);
            gameObject.GetComponentInParent<Cinemachine.CinemachineDollyCart>().m_Speed = 90f;
            abilityTime += -0.25f;
            updateUIAbility.Invoke(abilityTime);
            abilityLastUsed = Time.time;

        }
        else
        {
            cam.fieldOfView = 80;
            gameObject.GetComponentInParent<Cinemachine.CinemachineDollyCart>().m_Speed = 50f;



        }



    }
    //Maybe used a "Recharge State" to implement this in a better way
    void abilityRecharge()
    {
        if (abilityLastUsed + abilityRechargeCooldown < Time.time)
        {
            if (abilityTime < 100f)
            {
                abilityTime += 0.25f;
                updateUIAbility.Invoke(abilityTime);
            }
        }

    }
}
