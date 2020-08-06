using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UniversalEnemy : MonoBehaviour
{
    private Transform Target;
    public Transform ShootPoint;
    public Transform Bullet1;
    public Transform Bullet2;
    private int TargetNum;
    public float Speed;
    public float FireRate;
    public float FireRateLimit;
    public float StopDistance;
    public bool HasStopped;

    // Start is called before the first frame update
    void Start()
    {
        TargetNum = Random.Range(1, 2);

        if(TargetNum == 1)
        {
            Target = GameObject.FindGameObjectWithTag("Tower1").GetComponent<Transform>();
        }
        else if(TargetNum == 2)
        {
            Target = GameObject.FindGameObjectWithTag("Tower2").GetComponent<Transform>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        FireRate++;

        if (Vector2.Distance(transform.position, Target.position) > StopDistance && Target != null)
        {
            transform.position = Vector2.MoveTowards(transform.position, Target.position, Speed * Time.deltaTime);
        }
        else if (Vector2.Distance(transform.position, Target.position) < StopDistance && Target != null)
        {
            transform.position = transform.position;
            HasStopped = true;
        }


        if (FireRate >= FireRateLimit && HasStopped == true && TargetNum == 1)
        {
            //StartCoroutine(Shoot());
            Instantiate(Bullet1, ShootPoint.position, ShootPoint.rotation);
            FireRate = 0;
        }
        else if(FireRate >= FireRateLimit && HasStopped == true && TargetNum == 2)
        {
            Instantiate(Bullet2, ShootPoint.position, ShootPoint.rotation);
            FireRate = 0;
        }

        if(GameObject.FindGameObjectWithTag("Tower1") == null)
        {
            Target = GameObject.FindGameObjectWithTag("Tower2").GetComponent<Transform>();
        }

        if (GameObject.FindGameObjectWithTag("Tower2") == null)
        {
            Target = GameObject.FindGameObjectWithTag("Tower1").GetComponent<Transform>();
        }

        if (GameObject.FindGameObjectWithTag("Tower1") == null && GameObject.FindGameObjectWithTag("Tower2") == null)
        {
            return;
        }

    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Sparks")
        {
            Debug.Log("Enemy1 Hit");
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Sparks")
        {
            Debug.Log("Enemy1 Hit");
        }
    }
}

