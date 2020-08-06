using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript : MonoBehaviour
{
    public float SpawnTimer = 0;
    public float SpawnLimit;
    public float StopTime;
    public float MinusTime;
    public float DefaultTime;
    public bool WaveIsOver = false;
    public float WaveNum = 1;
    public GameObject[] Enemies;
    public Transform[] SpawnPoints;
    private int RandEnemy;
    private int RandPoint;
    public int MinPoint;
    public int MaxPoint;


    IEnumerator Waves()
    {
        //Instantiate(Enemies[RandEnemy], SpawnPoints[RandPoint].position, Quaternion.identity);
        yield return new WaitForSeconds(StopTime);
        if (WaveIsOver == false)
        {
            Instantiate(Enemies[RandEnemy], SpawnPoints[RandPoint].position, Quaternion.identity);
            WaveIsOver = true;
            StopTime = StopTime - MinusTime;
        }
        /*
        Instantiate(Enemies[RandEnemy], SpawnPoints[RandPoint].position, Quaternion.identity);
        WaveIsOver = false;
        StopTime = StopTime + AddTime;
        //SpawnTimer = 0;
        */
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //SpawnTimer++;
        RandEnemy = Random.Range(0, 2);
        RandPoint = Random.Range(MinPoint, MaxPoint);

        if(WaveIsOver == true)
        {
            SpawnTimer++;
        }

        if (SpawnTimer >= SpawnLimit)
        {
            WaveIsOver = false;
        }

        if (StopTime <= 0)
        {
            StopTime = DefaultTime;
        }

        StartCoroutine(Waves());

        if(GameObject.FindGameObjectsWithTag("Enemy1").Length == 0 && GameObject.FindGameObjectsWithTag("Enemy2").Length == 0)
        {
            WaveIsOver = false;
            //SpawnTimer = 0;
        }

    }
}
