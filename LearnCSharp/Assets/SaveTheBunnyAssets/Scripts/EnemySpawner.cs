using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemy;
    public float xPositionLimit;
    public float spawnRate;

    // Start is called before the first frame update
    void Start()
    {
        StartSpawning();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Spawns spikes at height of object
    void SpawnSpike()
    {
        float randomX = Random.Range(-xPositionLimit, xPositionLimit);

        Vector2 spawnPostion = new Vector2(randomX, transform.position.y);

        Instantiate(enemy, spawnPostion, Quaternion.identity);
    }

    //Uses InvokeRepeating to call a function repeatively after a set amount of time.
    void StartSpawning()
    {
        InvokeRepeating("SpawnSpike", 1f, spawnRate);
    }

    //Uses CancelInvoke to stop invoking a function.
    void StopSpawning()
    {
        CancelInvoke("SpawnSpike");
    }
}
