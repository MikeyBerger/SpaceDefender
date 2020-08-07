using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UniversalEnemyV2 : MonoBehaviour
{
    public Transform Bullet;
    public Transform ShootPoint;
    private Transform Target;
    public float Speed;
    public float StopDistance;
    public float FireRate;
    public float FireLimit;
    private bool Stopped = false;

    // Start is called before the first frame update
    void Start()
    {
        Target = GameObject.FindGameObjectWithTag("Tower1").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        

        if (Vector2.Distance(transform.position, Target.position) > StopDistance)
        {
            transform.Translate(0, Speed, 0);
            Stopped = false;
        }
        else if(Vector2.Distance(transform.position, Target.position) <= StopDistance)
        {
            transform.position = transform.position;
            Stopped = true;
        }

        FireRate++;

        if (FireRate >= FireLimit && Stopped == true)
        {
            Instantiate(Bullet, ShootPoint.position, ShootPoint.rotation);
            FireRate = 0;
        }
    }
}
