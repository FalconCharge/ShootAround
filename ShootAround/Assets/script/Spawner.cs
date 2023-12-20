using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] float StartTimeBTWSpawn;
    [SerializeField] GameObject[] enemies;
    private float timeBTWSpawn;

    private Transform[] spawnPoints;
    // Start is called before the first frame update
    void Start()
    {
        GameObject[] spawnPointObjects = GameObject.FindGameObjectsWithTag("SpawnPoints");

        spawnPoints = new Transform[spawnPointObjects.Length];

        for (int i = 0; i < spawnPointObjects.Length; i++)
        {
            spawnPoints[i] = spawnPointObjects[i].transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time > timeBTWSpawn)
        {
            timeBTWSpawn = Time.time + StartTimeBTWSpawn;
            //Decrease the interval between the spawnws
            if(StartTimeBTWSpawn > 0.40f)
            {
                StartTimeBTWSpawn -= 0.02f;
            }
            spawnEnemy();
        }
    }
    void spawnEnemy()
    {
        if (spawnPoints.Length == 0 || enemies.Length == 0)
        {
            Debug.LogError("No spawn points or enemies defined.");
            return;
        }
        //Spawns an enemy at a random point and picks a random enemy
        int indexPoint = Random.Range(0, spawnPoints.Length);
        int indexEnemy = Random.Range(0, enemies.Length);
        Instantiate(enemies[indexEnemy], spawnPoints[indexPoint].position, Quaternion.identity);
    }
}
