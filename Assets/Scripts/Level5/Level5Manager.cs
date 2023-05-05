using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Level5Manager : MonoBehaviour
{
    [SerializeField]
    GameObject PlayerRailCart;
    Cinemachine.CinemachineDollyCart dollyCart;
    [SerializeField]
    GameObject EnemySpawnPoint;
    public Transform DuelingFighter;

    public UnityEvent startDialogue;
    public UnityEvent spawnSquads;

    private bool isCoroutineRunning = false;

    private float distance;

    void Start()
    {
        dollyCart = PlayerRailCart.GetComponent<Cinemachine.CinemachineDollyCart>();
        startDialogue.Invoke();
        var newDuelingFighter = Instantiate(DuelingFighter, EnemySpawnPoint.transform.position, Quaternion.identity);
        newDuelingFighter.transform.parent = EnemySpawnPoint.transform;
    }


    void Update()
    {
        distance = dollyCart.m_Position;
        if(distance < 17000)
        {
            StartCoroutine(SpawnDuelers());
        }
        if(distance > 15000)
        {
            spawnSquads.Invoke();
        }
       

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
