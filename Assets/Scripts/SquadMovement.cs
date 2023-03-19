using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquadMovement : MonoBehaviour
{

    
    // Start is called before the first frame update
    void Start()
    {
        //parent.GetComponent<Cinemachine.CinemachineDollyCart>().m_Position;
    }

    // Update is called once per frame
    void Update()
    {

        transform.Translate(Vector3.forward * 30 * Time.deltaTime, Space.Self);
  
    }
}
