using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScriptV4 : MonoBehaviour
{
    public Transform[] Spawners;
    public Transform Enemy;
    public float DefaultDelay;
    public float RegDelay;

    IEnumerator SpawnWaves()
    {
        #region Instances
        Instantiate(Enemy, Spawners[0].position, Quaternion.identity);
        Instantiate(Enemy, Spawners[1].position, Quaternion.identity);
        Instantiate(Enemy, Spawners[2].position, Quaternion.identity);
        Instantiate(Enemy, Spawners[3].position, Quaternion.identity);
        Instantiate(Enemy, Spawners[4].position, Quaternion.identity);
        Instantiate(Enemy, Spawners[5].position, Quaternion.identity);
        Instantiate(Enemy, Spawners[6].position, Quaternion.identity);
        Instantiate(Enemy, Spawners[7].position, Quaternion.identity);
        Instantiate(Enemy, Spawners[8].position, Quaternion.identity);
        Instantiate(Enemy, Spawners[9].position, Quaternion.identity);
        #endregion
        yield return new WaitForSeconds(DefaultDelay);
        DefaultDelay = RegDelay;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(SpawnWaves());

        StopCoroutine(SpawnWaves());
    }

    
}
