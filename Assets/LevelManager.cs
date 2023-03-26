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

    public UnityEvent destroyFirstFreighter;
    public UnityEvent secondSquadJumps;
    public UnityEvent destroySecondFreighter;

    private void Start()
    {
        dollyCart = PlayerRailCart.GetComponent<Cinemachine.CinemachineDollyCart>();
    }

    private void Update()
    {
        pathProgress = dollyCart.m_Position;

        if(pathProgress > 75)
        {
            destroyFirstFreighter.Invoke();
        }
        
        if(pathProgress > 600)
        {
            secondSquadJumps.Invoke();
        }

       if(pathProgress > 800)
        {
            destroySecondFreighter.Invoke();
        }
    }
}
