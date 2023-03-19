using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveTextManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time > 5)
        {
            gameObject.SetActive(false);
        }
    }
}
