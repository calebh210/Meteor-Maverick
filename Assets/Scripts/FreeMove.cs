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
        player = this.gameObject.transform.GetChild(0);
        playerModel = player.GetChild(0);
    }

    // Update is called once per frames
    void Update()
    {
       
        //This moves the playercam parent along its LOCAL rotation
        transform.Translate(Vector3.forward * 50 * Time.deltaTime, Space.Self);

        Vector3 screenPos = Camera.main.WorldToViewportPoint(playerModel.transform.position);

        float horizontal = Input.GetAxis("Horizontal");
        

        //TODO!!! TURN OFF CAMERA CLAMPING WHILE IN FREEMOVE! MAKES FREEMOVE FEEL MUCH BETTER


        //The screen will only rotate if the player flies to the side
        if(screenPos.x < 0.4 && horizontal < 0)
        {
            transform.Rotate(0, horizontal/2, 0);
        }

        if (screenPos.x > 0.6 && horizontal > 0)
        {
            transform.Rotate(0, horizontal/2, 0);
        }

        /* Vector3 newRotate = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y + horizontal, transform.eulerAngles.z);
         transform.eulerAngles = newRotate;*/


        //Debug.Log(horizontal);





    }
}
