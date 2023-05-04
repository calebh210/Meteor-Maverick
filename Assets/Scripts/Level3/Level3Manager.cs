using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level3Manager : MonoBehaviour
{
    [SerializeField]
    GameObject PlayerRailCart;
    Cinemachine.CinemachineDollyCart dollyCart;
    float pathProgress;
    [SerializeField]
    GameObject EnemySpawnPoint;
    public Transform DuelingFighter;
    bool DuelerSpawned = false;
    
    void Start()
    {
        dollyCart = PlayerRailCart.GetComponent<Cinemachine.CinemachineDollyCart>();
    }

    
    void Update()
    {
        pathProgress = dollyCart.m_Position;
       /* if (pathProgress >= 10 && DuelerSpawned == false)
        {
            var newDuelingFighter = Instantiate(DuelingFighter, EnemySpawnPoint.transform.position, EnemySpawnPoint.transform.rotation);
            newDuelingFighter.transform.parent = EnemySpawnPoint.transform;
            DuelerSpawned = true;
        }*/
       
    }
}
