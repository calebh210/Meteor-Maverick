using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Level3Manager : MonoBehaviour
{
    [SerializeField]
    GameObject PlayerRailCart;
    Cinemachine.CinemachineDollyCart dollyCart;
    [SerializeField]
    GameObject EnemySpawnPoint;
    public Transform DuelingFighter;

    public UnityEvent startDialogue;

    private bool isCoroutineRunning = false;
    
    void Start()
    {
       startDialogue.Invoke();
       var newDuelingFighter = Instantiate(DuelingFighter, EnemySpawnPoint.transform.position, Quaternion.identity);
       newDuelingFighter.transform.parent = EnemySpawnPoint.transform;
    }

    
    void Update()
    {
        StartCoroutine(SpawnDuelers());
       
    }

    public IEnumerator SpawnDuelers()
    {
       

        if (isCoroutineRunning)
        {
            yield break;
        }

        isCoroutineRunning = true;

        yield return new WaitForSeconds(20f);
        var newDuelingFighter = Instantiate(DuelingFighter, EnemySpawnPoint.transform.position, Quaternion.identity);
        newDuelingFighter.transform.parent = EnemySpawnPoint.transform;
    

        isCoroutineRunning = false;
    }

     
}
