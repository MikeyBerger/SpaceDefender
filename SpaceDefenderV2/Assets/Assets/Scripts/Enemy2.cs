using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : MonoBehaviour
{

    public float Health;
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
    public float WaitTime;
    public bool HasStopped;
   


    IEnumerator Shoot()
    {
        yield return new WaitForSeconds(WaitTime);
        Instantiate(Bullet, ShootPoint.position, ShootPoint.rotation);
    }

    // Start is called before the first frame update
    void Start()
    {
    
        Target = GameObject.FindGameObjectWithTag("Tower1").GetComponent<Transform>();


     
    }

    // Update is called once per frame
    void Update()
    {
        Damage = Random.Range(MinDamage, MaxDamage);


        if (Target == null)
        {
            Destroy(transform.gameObject);
        }


        if (Health <= 0)
        {
            Destroy(transform.gameObject);
        }






        FireRate++;

        if (Vector2.Distance(transform.position, Target.position) > StopDistance && Target != null)
        {
            transform.position = Vector2.MoveTowards(transform.position, Target.position, Speed * Time.deltaTime);
        }
        else if (Vector2.Distance(transform.position, Target.position) < StopDistance && Target != null)
        {
            transform.position = transform.position;
            //HasStopped = true;
        }
        else
        {
            Destroy(transform.gameObject);
        }


        if (FireRate >= FireRateLimit /*&& HasStopped == true*/)
        {
            //StartCoroutine(Shoot());
            Instantiate(Bullet, ShootPoint.position, ShootPoint.rotation);
            FireRate = 0;
        }






    }

    #region Not In Use
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Sparks")
        {
            Debug.Log("Enemy2 Hit");
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Sparks")
        {
            Debug.Log("Enemy2 Hit");
        }
    }
    #endregion



}
