using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveCrosshair : MonoBehaviour
{
    public Vector2 crossLimits = new Vector2(2, 4);
    public Camera cam;
    public Transform FirePoint;
    public GameObject crossPos;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = cam.WorldToScreenPoint(crossPos.transform.position);
    }

    private void LateUpdate()
    {
        transform.position = cam.WorldToScreenPoint(crossPos.transform.position);
    
    }

}


