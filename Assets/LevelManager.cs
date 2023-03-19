using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{

    GameObject parent;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(parent.GetComponent<Cinemachine.CinemachineDollyCart>().m_Position <= 3600)
        {

        }
    }
}
