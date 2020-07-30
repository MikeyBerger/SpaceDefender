using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public int Damage;
    public float FireRate;
    public LayerMask NotToHit;
    public float TimeToFire;
    public Transform FirePoint;
    public Transform Bullet;
    public Transform MuzzleFlash;
    public Transform Sparks;
#pragma warning disable IDE0051 // Remove unused private members
    private float FlashSize;
#pragma warning restore IDE0051 // Remove unused private members
    public float MaxSize;
    public float MinSize;
    public bool HitEnemy = false;
    private EnemyAnim EA;
    public int Enemy1HitCount;
    public int Enemy2HitCount;
    private Transform Target;
    public int TargetHitCount;
    private Enemy1 E1;
    private Enemy2 E2;




    // public float HitTimer;

#pragma warning disable IDE0051 // Remove unused private members
    IEnumerator EffectDelay()
#pragma warning restore IDE0051 // Remove unused private members
    {
        yield return new WaitForSeconds(1f);
    }

    /*
    IEnumerator MissedEnemy()
    {
        yield return new WaitForSeconds(HitTimer);
        HitEnemy = false;
    }
    */

    private void Awake()
    {
        E1 = GameObject.FindObjectOfType<Enemy1>();
        E2 = GameObject.FindObjectOfType<Enemy2>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Shoot();
        FlashSize = UnityEngine.Random.Range(MinSize, MaxSize);
        MuzzleFlash.localScale = new Vector3(FlashSize, FlashSize, FlashSize);

        if(FireRate == 0)
        {
            if (Input.GetButtonDown("Fire1"))
            {
               // SingleFire();
                Shoot();
               
            }else if(Input.GetButton("Fire1") && Time.time > TimeToFire)
            {
                TimeToFire = Time.time + 1 / FireRate;
               // RapidFire();
                Shoot();
               
            }
        }

    }

    void SingleFire()
    {
        Debug.Log("Player is shooting single fire");
    }

    void RapidFire()
    {
        Debug.Log("Player is shooting rapid fire");
    }

    public void Shoot()
    {
        Vector2 MousePos = new Vector2(Camera.main.ScreenToWorldPoint (Input.mousePosition).x, Camera.main.ScreenToWorldPoint (Input.mousePosition).y);
        Vector2 FirePointPos = new Vector2(FirePoint.position.x, FirePoint.position.y);
        Instantiate(Bullet, FirePoint.position, FirePoint.rotation);
        Instantiate(MuzzleFlash, FirePoint.position, FirePoint.rotation);
        RaycastHit2D Hit = Physics2D.Raycast(FirePointPos, MousePos - FirePointPos, 100);
        Debug.DrawLine(FirePointPos, (MousePos - FirePointPos) * 100);
        Vector2 HitPos = new Vector2(Hit.transform.position.x, Hit.transform.position.y);

        if(Hit.collider != null)
        {
            Debug.DrawLine(FirePointPos, Hit.point, Color.red);
        }
        
        if(Hit.collider.gameObject.tag == "Enemy1")
        {
            HitEnemy = true;
            Debug.Log("Enemy1 hit");
            TargetHitCount = 0;
            //StartCoroutine(MissedEnemy());
            //DamageEnemy1();
            //GS.stats.EnemyHealth = GS.stats.EnemyHealth - Damage;
            // Enemy1HitCount = Enemy1HitCount + 1;
            //  Instantiate(Sparks, HitPos, Sparks.rotation);

            E1.Health = E1.Health - E1.Damage;

            if (Enemy1HitCount >= 4)
            {
                Destroy(Hit.transform.gameObject);
            }
        }
        else if (Hit.collider.gameObject.tag == "Enemy2")
        {
            HitEnemy = true;
            Debug.Log("Enemy2 hit");
            //StartCoroutine(MissedEnemy());
            //DamageEnemy1();
            //GS.stats.EnemyHealth = GS.stats.EnemyHealth - Damage;
            // Enemy2HitCount = Enemy2HitCount + 1;
            // Instantiate(Sparks, HitPos, Sparks.rotation);

            E2.Health = E2.Health - Damage;

            if (Enemy2HitCount >= 4)
            {
                Destroy(Hit.transform.gameObject);
            }
        }

    }

}
