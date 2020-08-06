using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScriptV2 : MonoBehaviour
{

    public enum SpawnState { SPAWNING, WAITING, COUNTING };// Note: the letters do NOT have to be CAPITALIZED

    [System.Serializable]
    public class Wave
    {
        public string Name;
        public GameObject[] Enemies;
        public int WaveCount;
        public float SpawnRate;
        public int RandEnemy = Random.Range(0, 2);
        public Transform[] SpawnPoints;
        public int RandPoint = Random.Range(0, 3);
    }

    public Wave[] Waves;
    private int NextWave = 0;
    public float TimeBTWNWaves = 5f;
    public float WaveCountDown;
    public SpawnState State = SpawnState.COUNTING;
    public float SearchCountDown = 1f;


    IEnumerator SpawnWave(Wave _Wave)
    {
        Debug.Log("Spawning Wave: " + _Wave.Name);
        State = SpawnState.SPAWNING;

        for (int i = 0; i < _Wave.WaveCount; i++)
        {
            SpawnEnemies(_Wave);//Spawning logic goes here
            yield return new WaitForSeconds(1f / _Wave.SpawnRate);
        }

        State = SpawnState.WAITING;

        yield break;
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


    // Start is called before the first frame update
    void Start()
    {
        WaveCountDown = TimeBTWNWaves;
    }

    // Update is called once per frame
    void Update()
    {
        if (State == SpawnState.WAITING)
        {
            if (!EnemiesAreAlive())
            {
                WaveCompleted(); //Begin a new wave
            }
            else
            {
                return;
            }
        }


        if (WaveCountDown <= 0)
        {
            if (State != SpawnState.SPAWNING)
            {
                StartCoroutine(SpawnWave(Waves[NextWave])); //Start spawning waves
            }
            else
            {
                WaveCountDown -= Time.deltaTime;
            }
        }
    }

    void SpawnEnemies(Wave _Wave)
    {
        Instantiate(_Wave.Enemies[_Wave.RandEnemy], _Wave.SpawnPoints[_Wave.RandPoint].position, Quaternion.identity);
        Debug.Log("Enemy has spawned");
    }

    void WaveCompleted()
    {
        Debug.Log("Wave Completed");

        State = SpawnState.COUNTING;
        WaveCountDown = TimeBTWNWaves;

        if (NextWave + 1 > Waves.Length - 1)
        {
            NextWave = 0;
            Debug.Log("All Waves Completed");
        }
        else
        {
            NextWave++;
        }
        
    }
}
