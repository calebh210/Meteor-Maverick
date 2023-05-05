using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Level1Manager : MonoBehaviour
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
    public UnityEvent showFinishingText;



    private void Start()
    {
        dollyCart = PlayerRailCart.GetComponent<Cinemachine.CinemachineDollyCart>();
        //Resetting the score on every fresh start of the game
        PlayerPrefs.SetInt("score", 0);
        FindObjectOfType<GameManager>().UpdateScore(0);
    }

    private void Update()
    {
        //Tracking player progress along rail - make events happen at certain distances
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

        if(pathProgress > 3100)
        {
            spawnThirdGroup.Invoke();
        }

        if(pathProgress > 3700)
        {
            spawnFourthGroup.Invoke();
        }

        if(pathProgress > 5100)
        {
            dollyCart.m_Speed = 0;
        }

        if(pathProgress > 4300)
        {
            showFinishingText.Invoke();
        }
    }
}
