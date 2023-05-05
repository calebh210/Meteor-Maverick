using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


// fix bug with flashing dialogue box
public class Level2Manager : MonoBehaviour
{
    [SerializeField]
    GameObject PlayerRailCart;
    Cinemachine.CinemachineDollyCart dollyCart;
    float pathProgress;

    public UnityEvent switchToFree;
    public UnityEvent startDialogue;

    private void Start()
    {
        dollyCart = PlayerRailCart.GetComponent<Cinemachine.CinemachineDollyCart>();
        startDialogue.Invoke();
    }

    private void Update()
    {
        pathProgress = dollyCart.m_Position;


        if (pathProgress > 6800) 
        { 
            switchToFree.Invoke();
        }

    }


}
