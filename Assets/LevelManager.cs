using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LevelManager : MonoBehaviour
{
    [SerializeField]
    GameObject PlayerRailCart;
    Cinemachine.CinemachineDollyCart dollyCart;
    float pathProgress;
    bool hasRun = false;
    public UnityEvent destroyFirstFreighter;
    public UnityEvent secondSquadJumps;
    public UnityEvent destroySecondFreighter;
    public UnityEvent spawnFirstGroup;

    

    private void Start()
    {
        dollyCart = PlayerRailCart.GetComponent<Cinemachine.CinemachineDollyCart>();
    }

    private void Update()
    {
        pathProgress = dollyCart.m_Position;

        if(pathProgress > 75 & hasRun == false )
        {
            destroyFirstFreighter.Invoke();
            hasRun = true;
        }
        
        if(pathProgress > 600)
        {
            secondSquadJumps.Invoke();
        }

       if(pathProgress > 800)
        {
            destroySecondFreighter.Invoke();
        }

        if (pathProgress > 1300)
        {
            spawnFirstGroup.Invoke();
        }
    }
}
