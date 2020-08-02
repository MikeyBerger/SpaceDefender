using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public int Health;
    private int Damage;
    public Transform Explosion;
    public float RestorationTimer;
    private int RegenHealth;
    public int MaxRegen;
    public int MinRegen;
    public int MaxDamage;
    public int MinDamage;
    public HealthBarScript HBS;

    IEnumerator RestoreHealth()
    {
        yield return new WaitForSeconds(RestorationTimer);
        Health = Health + RegenHealth;
    }



    // Start is called before the first frame update
    void Start()
    {
        HBS.SetMaxHealth(Health);
    }

    // Update is called once per frame
    void Update()
    {
        RegenHealth = Random.Range(MinRegen, MaxRegen);
        Damage = Random.Range(MinDamage, MaxDamage);

        if(Health <= 0)
        {
            Destroy(transform.gameObject);
        }

        StartCoroutine(RestoreHealth());
    }

    /*
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.transform.tag == "Fire")
        {
            Health = Health - Damage;
            //Debug.Log("Tower was hit!");
            Instantiate(Explosion, collision.gameObject.transform.position, collision.gameObject.transform.rotation);
            Destroy(collision.gameObject);
            
        }
    }
    */

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.transform.tag == "Fire")
        {
            Health = Health - Damage;
            HBS.SetHealth(Health - Damage);
            //Debug.Log("Tower was hit!");
            Instantiate(Explosion, collision.gameObject.transform.position, collision.gameObject.transform.rotation);
            Destroy(collision.gameObject);

        }
    }
}
