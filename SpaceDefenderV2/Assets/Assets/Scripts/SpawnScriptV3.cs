using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScriptV3 : MonoBehaviour
{
    public GameObject[] Enemies;
    public Transform[] SpawnPoints;
    public bool StopSpawning = false;
    private float SpawnTime;
    public float MinSpawnTime;
    public float MaxSpawnTime;
    private float DelayTime;
    public float MinDelayTime;
    public float MaxDelayTime;
    private int RandEnemy;
    private int RandPoint;
    private float SearchCountDown = 1f;

    // Start is called before the first frame update
    void Start()
    {
        
        
        DelayTime = Random.Range(MinDelayTime, MaxDelayTime);
        SpawnTime = Random.Range(MinSpawnTime, MaxSpawnTime);

        if (!StopSpawning)
        {
            InvokeRepeating("StartSpawning", SpawnTime, DelayTime);
        }

    }

    // Update is called once per frame
    void Update()
    {
        RandEnemy = Random.Range(0, 2);
        RandPoint = Random.Range(0, 3);
    }

    void StartSpawning()
    {
        Instantiate(Enemies[RandEnemy], SpawnPoints[RandPoint].position, Quaternion.identity);
        Instantiate(Enemies[RandEnemy], SpawnPoints[RandPoint].position, Quaternion.identity);
        Instantiate(Enemies[RandEnemy], SpawnPoints[RandPoint].position, Quaternion.identity);
        if (StopSpawning)
        {
            CancelInvoke("StartSpawning");
        }
    }

    bool EnemiesAreAlive()
    {
        SearchCountDown -= Time.deltaTime;

        if (SearchCountDown <= 0)
        {
            SearchCountDown = 1f;

            if (GameObject.FindGameObjectWithTag("Enemy1") == null && GameObject.FindGameObjectWithTag("Enemy2") == null)
            {
                return false;
            }
        }


        return true;
    }
}
