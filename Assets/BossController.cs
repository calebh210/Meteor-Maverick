using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    private float health;

    BossWeakpointController WeakPoint1;
    BossWeakpointController WeakPoint2;
    BossWeakpointController WeakPoint3;
    BossWeakpointController WeakPoint4;

    private void Start()
    {
        WeakPoint1 = transform.Find("WeakPoint1").GetComponent<BossWeakpointController>();
        WeakPoint2 = transform.Find("WeakPoint2").GetComponent<BossWeakpointController>();
        WeakPoint3 = transform.Find("WeakPoint3").GetComponent<BossWeakpointController>();
        WeakPoint4 = transform.Find("WeakPoint4").GetComponent<BossWeakpointController>();
    }

    private void Update()
    {
        health = WeakPoint1.getHealth() + WeakPoint2.getHealth() + WeakPoint3.getHealth() + WeakPoint4.getHealth();

        if(health <= 0)
        {
            Debug.Log("Level Finished");
        }
    }
}
