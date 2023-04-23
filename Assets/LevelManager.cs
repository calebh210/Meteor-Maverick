using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LevelManager : MonoBehaviour
{
    [SerializeField]
    GameObject PlayerRailCart;
    [SerializeField]
    GameObject EnemySpawnPoint;
    [SerializeField]
    GameObject DuelingFighter;
    Cinemachine.CinemachineDollyCart dollyCart;
    float pathProgress;
    bool hasRun = false;
    bool spawnedDueler = false;
    public UnityEvent destroyFirstFreighter;
    public UnityEvent secondSquadJumps;
    public UnityEvent destroySecondFreighter;
    public UnityEvent spawnFirstGroup;
    public UnityEvent spawnSecondGroup;
    public UnityEvent spawnThirdGroup;
    public UnityEvent spawnFourthGroup;



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

        if(pathProgress > 1800)
        {
            spawnSecondGroup.Invoke();
        }

        if(pathProgress > 2300 & !spawnedDueler)
        {
            var newDuelingFighter = Instantiate(DuelingFighter, EnemySpawnPoint.transform.position, EnemySpawnPoint.transform.rotation);
            newDuelingFighter.transform.parent = EnemySpawnPoint.transform;
            spawnedDueler = true;
        }

        if(pathProgress > 5100)
        {
            dollyCart.m_Speed = 0;
        }
    }
}
