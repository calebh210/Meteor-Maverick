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

    public customFloatEvent updateUIAbility;

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
            //cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, 60, Time.deltaTime * 2f);
            //cam.transform.localPosition = new Vector3(0, 0, -6f);

            gameObject.GetComponentInParent<Cinemachine.CinemachineDollyCart>().m_Speed = 20f;
            abilityTime += -0.25f;
            updateUIAbility.Invoke(abilityTime);
            abilityLastUsed = Time.time;


        }
        else
        {
            //cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, 110, Time.deltaTime  * 2f);
            //cam.transform.localPosition = new Vector3(0, 0, -8f);
            gameObject.GetComponentInParent<Cinemachine.CinemachineDollyCart>().m_Speed = 50f;


        }
    }

    public void BoostZoomOut(bool status)
    {
        if (status && abilityTime > 0)
        {
            //cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, 120, Time.deltaTime);
            //cam.transform.localPosition = new Vector3(0,0,-12f);

            gameObject.GetComponentInParent<Cinemachine.CinemachineDollyCart>().m_Speed = 90f;
            abilityTime += -0.25f;
            updateUIAbility.Invoke(abilityTime);
            abilityLastUsed = Time.time;



        }
        else
        {
            //cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, 110, Time.deltaTime);
            //cam.transform.localPosition = new Vector3(0, 0, -8f);
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
