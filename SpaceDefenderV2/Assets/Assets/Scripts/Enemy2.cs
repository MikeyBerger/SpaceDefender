﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : MonoBehaviour
{

    public float Health;
    public float Speed;
    public float StopDistance;
    public float FireRate;
    public float FireRateLimit;
    public Transform ShootPoint;
    public Transform Bullet;
    public Transform Target;
    public bool HasStopped;
    public Animator Anim;
    private Weapon _Weapon;

    // Start is called before the first frame update
    void Start()
    {
        Anim = GetComponent<Animator>();
        Target = GameObject.FindGameObjectWithTag("Tower2").GetComponent<Transform>();
        _Weapon = GetComponent<Weapon>();
    }

    // Update is called once per frame
    void Update()
    {
        FireRate++;

        if (Vector2.Distance(transform.position, Target.position) > StopDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, Target.position, Speed * Time.deltaTime);
        }
        else if (Vector2.Distance(transform.position, Target.position) < StopDistance)
        {
            transform.position = transform.position;
            HasStopped = true;
        }


        if (FireRate >= FireRateLimit && HasStopped == true)
        {
            Instantiate(Bullet, ShootPoint.position, ShootPoint.rotation);
            FireRate = 0;
        }

        if (_Weapon.HitEnemy == true)
        {
            Anim.SetBool("WasHit", true);
        }
        else
        {
            Anim.SetBool("WasHit", false);
        }
    }
}
