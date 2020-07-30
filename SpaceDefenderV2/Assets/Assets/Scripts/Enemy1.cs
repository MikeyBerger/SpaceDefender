using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : MonoBehaviour
{
    public int Health;
    public float Speed;
    public int Damage;
    public int MinDamage;
    public int MaxDamage;
    public float StopDistance;
    public float FireRate;
    public float FireRateLimit;
    public Transform ShootPoint;
    public Transform Bullet;
    public Transform Target;
   // public bool HasStopped;
   


    // Start is called before the first frame update
    void Start()
    {
        
        Target = GameObject.FindGameObjectWithTag("Tower1").GetComponent<Transform>();
        if(Target == null)
        {
            Target = GameObject.FindGameObjectWithTag("Tower2").GetComponent<Transform>();
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        Damage = Random.Range(MinDamage, MaxDamage);

        if (Health <= 0)
        {
            Destroy(transform.gameObject);
        }

        FireRate++;

        if(Vector2.Distance(transform.position, Target.position) > StopDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, Target.position, Speed * Time.deltaTime);
        } else if(Vector2.Distance(transform.position, Target.position) < StopDistance)
        {
            transform.position = transform.position;
            //HasStopped = true;
        }


        if(FireRate >= FireRateLimit /*&& HasStopped == true*/)
        {
            Instantiate(Bullet, ShootPoint.position, ShootPoint.rotation);
            FireRate = 0;
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Sparks")
        {
            Debug.Log("Enemy1 Hit");
        }
    }


}
