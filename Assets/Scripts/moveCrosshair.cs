using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveCrosshair : MonoBehaviour
{
    Camera cam;
    public GameObject crossPos;
    
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
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


