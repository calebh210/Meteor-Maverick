using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveCrosshair : MonoBehaviour
{
    public Vector2 crossLimits = new Vector2(2, 4);
    public Camera cam;
    public Transform FirePoint;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        /* float horizontal = Input.GetAxis("Mouse X");
         float vertical = Input.GetAxis("Mouse Y");

         transform.position += new Vector3(horizontal, vertical, 0) * 300 * Time.deltaTime;*/

        /* Vector3 mousePos = Input.mousePosition;
         transform.position = mousePos;*/
        /*transform.localPosition = new Vector3(Mathf.Clamp(mousePos.x, -crossLimits.x, crossLimits.x), Mathf.Clamp(mousePos.y, -crossLimits.y, crossLimits.y), mousePos.z);*/
        /*      if(horizontal == 0 && vertical == 0)
              {
                  if(transform.position.x > crossLimits.x && transform.position.y > crossLimits.y)
                  {
                      transform.position = new Vector3(0, 0, 0);
                  }
              }*/

        RaycastHit hit;
        if (Physics.Raycast(FirePoint.transform.position, FirePoint.transform.forward, out hit))
        {
            if (hit.collider.gameObject.tag == "HitPlane")
            {
                transform.position = cam.WorldToScreenPoint(hit.point);
            }
        }
    }

    private void LateUpdate()
    {
       
    }
}

