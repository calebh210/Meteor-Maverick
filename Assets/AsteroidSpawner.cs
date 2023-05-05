using System.Collections;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class AsteroidSpawner : MonoBehaviour
{
 
    //Defining the lists for the asteroids and spawners logic
    List<GameObject> Asteroids = new List<GameObject>();
    List<GameObject> Spawners = new List<GameObject>();
    public GameObject Asteroid1;
    public GameObject Asteroid2;
    public GameObject Asteroid3;
    public GameObject Asteroid4;
    public GameObject Asteroid5;
    public GameObject Asteroid6;
    public GameObject Asteroid7;
    public GameObject player;

    public GameObject Spawner1;
    public GameObject Spawner2;
    public GameObject Spawner3;

    public UnityEvent AsteroidsEnd;

    private bool isCoroutineRunning = false;

    private int timesRan = 0;

    void Start()
    {
        //Adding all the asteroid variations to a list
        Asteroids.Add(Asteroid1);
        Asteroids.Add(Asteroid2);
        Asteroids.Add(Asteroid3);
        Asteroids.Add(Asteroid4);
        Asteroids.Add(Asteroid5);
        Asteroids.Add(Asteroid6);
        Asteroids.Add(Asteroid7);

        //Adding all the spawn points to a list
        Spawners.Add(Spawner1);
        Spawners.Add(Spawner2);
        Spawners.Add(Spawner3);
       
    }

    private void Update()
    {
        if (timesRan < 90)
        {
            StartCoroutine(SpawnAsteroids());
        }

        if(timesRan == 90)
        {
            AsteroidsEnd.Invoke();
            //Setting timesRan to 91 so that the dialogue only shows once
            timesRan++;
        }
        
    }

    public IEnumerator SpawnAsteroids()
    {
        //setting the location of the follow spawner to the player's x and y
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y, 120);

        if (isCoroutineRunning)
        {
            yield break; 
        }

        isCoroutineRunning = true;

        yield return new WaitForSeconds(1f);

        int SpawnerIndex = Random.Range(0, 3);
        int AsteroidIndex = Random.Range(0, Asteroids.Count);

        var ast = Instantiate(Asteroids[AsteroidIndex], Spawners[SpawnerIndex].transform.position, transform.rotation);
        var ast2 = Instantiate(Asteroids[AsteroidIndex], gameObject.transform.position, transform.rotation);
        var speed = Random.Range(40000, 70000);

        ast.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0, 0, -speed));
        ast2.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0, 0, -speed));

        timesRan++;

        isCoroutineRunning = false;
    }

    
}
