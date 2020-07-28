using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public float Damage;
    public float FireRate;
    public LayerMask NotToHit;
    public float TimeToFire;
    public Transform FirePoint;
    public Transform Bullet;
    public Transform MuzzleFlash;
#pragma warning disable IDE0051 // Remove unused private members
    private float FlashSize;
#pragma warning restore IDE0051 // Remove unused private members
    public float MaxSize;
    public float MinSize;
    private Enemy1 E1;
    private Enemy2 E2;
    public bool HitEnemy = false;
    private EnemyAnim EA;

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

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Shoot();
        FlashSize = Random.Range(MinSize, MaxSize);
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

        if(HitEnemy == true)
        {
            
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

    private void Shoot()
    {
        Vector2 MousePos = new Vector2(Camera.main.ScreenToWorldPoint (Input.mousePosition).x, Camera.main.ScreenToWorldPoint (Input.mousePosition).y);
        Vector2 FirePointPos = new Vector2(FirePoint.position.x, FirePoint.position.y);
        Instantiate(Bullet, FirePoint.position, FirePoint.rotation);
        Instantiate(MuzzleFlash, FirePoint.position, FirePoint.rotation);
        RaycastHit2D Hit = Physics2D.Raycast(FirePointPos, MousePos - FirePointPos, 100);
        Debug.DrawLine(FirePointPos, (MousePos - FirePointPos) * 100);

        if(Hit.collider != null)
        {
            Debug.DrawLine(FirePointPos, Hit.point, Color.red);
        }
        
        if(Hit.collider.gameObject.tag == "Enemy")
        {
            HitEnemy = true;
            //Debug.Log("Enemy hit");
            //StartCoroutine(MissedEnemy());
            
        }
        
    }

}
