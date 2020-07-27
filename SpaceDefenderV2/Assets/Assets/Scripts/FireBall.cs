using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    public float Speed;
    public Transform Target;
    private Vector2 TargetVector;
    private Enemy EnemyScript;

    // Start is called before the first frame update
    void Start()
    {
        EnemyScript = GetComponent<Enemy>();
        if(EnemyScript.TowerNumber == 1)
        {
            Target = GameObject.FindGameObjectWithTag("Tower1").GetComponent<Transform>();
        }else if(EnemyScript.TowerNumber == 2)
        {
            Target = GameObject.FindGameObjectWithTag("Tower2").GetComponent<Transform>();
        }

        TargetVector = new Vector2(Target.position.x, Target.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, TargetVector, Speed * Time.deltaTime);
    }
}
