using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RailSwitcher : MonoBehaviour
{

    public GameObject bossText;
    float timeActive;


    private void Update()
    {
        if(GetComponent<Cinemachine.CinemachineDollyCart>().m_Position > 6800)
        {
            switchToFree();
            bossText.SetActive(true);
            timeActive = Time.time;
        }

        /*if(timeActive + 5 > Time.time)
        {
            bossText.SetActive(false);
        }*/
    }
    void switchToFree()
    {
        GetComponent<Cinemachine.CinemachineDollyCart>().enabled = false;
        GetComponent<FreeMove>().enabled = true;
    }
}
