using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreeMove : MonoBehaviour
{

    Transform player;
    Transform playerModel;
    // Start is called before the first frame update
    void Start()
    {
        player = this.gameObject.transform.GetChild(1);
        playerModel = player.GetChild(1);
    }

    // Update is called once per frame
    void Update()
    {
       
        transform.position += new Vector3(0, 0, 10) * 2 * Time.deltaTime;

        transform.rotation = playerModel.rotation;
        
    }
}
