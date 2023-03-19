using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RailSwitcher : MonoBehaviour
{

    private void Update()
    {
        if(GetComponent<Cinemachine.CinemachineDollyCart>().m_Position > 6800)
        {
            switchToFree();
        }
    }
    void switchToFree()
    {
        GetComponent<Cinemachine.CinemachineDollyCart>().enabled = false;
        GetComponent<FreeMove>().enabled = true;
    }
}
