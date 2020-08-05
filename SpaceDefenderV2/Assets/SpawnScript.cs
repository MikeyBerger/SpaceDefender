using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript : MonoBehaviour
{
    public float SpawnTimer = 0;
    public float SpawnLimit;
    public float StopTime;
    public bool WaveIsOver = false;
    public float WaveNum = 1;
    public GameObject[] Enemies;
    public Transform[] SpawnPoints;
    private int RandEnemy;
    private int RandPoint;
    public int MinPoint;
    public int MaxPoint;


    IEnumerator StopWave()
    {
        yield return new WaitForSeconds(WaveNum);
        Instantiate(Enemies[RandEnemy], SpawnPoints[RandPoint].position, Quaternion.identity);
        WaveIsOver = false;
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

        if(SpawnTimer >= SpawnLimit && WaveIsOver == false)
        {
            StartCoroutine(StopWave());
        }

        if(GameObject.FindGameObjectsWithTag("Enemy1").Length == 0 && GameObject.FindGameObjectsWithTag("Enemy2").Length == 0)
        {
            WaveIsOver = true;
            WaveNum = WaveNum + .2f;
            SpawnTimer = 0;
        }

        if(WaveNum <= 0)
        {
            WaveNum = 1;
        }
    }
}
