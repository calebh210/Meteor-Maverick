using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquadMovement : MonoBehaviour
{

    public GameObject parent;
    // Start is called before the first frame update
    void Start()
    {
        //parent.GetComponent<Cinemachine.CinemachineDollyCart>().m_Position;
    }

    // Update is called once per frame
    void Update()
    {

     transform.position += new Vector3(25, 0, 0) * Time.deltaTime;
  
    }
}
