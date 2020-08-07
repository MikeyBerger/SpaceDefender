using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public int Health;
    private int Damage;
    public Transform Explosion;
    public Transform ForceField;
    public Transform ForceFieldPoint;
    public float RestorationTimer;
    private int RegenHealth;
    public int MaxRegen;
    public int MinRegen;
    public int MaxDamage;
    public int MinDamage;
    public float ForceFieldEnergy;
    public HealthBarScript HBS;

    IEnumerator RestoreForceField()
    {
        yield return new WaitForSeconds(RestorationTimer);
        ForceFieldEnergy++;
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
        /*
        if(Health < 100)
        {
            StartCoroutine(RestoreHealth());
        }
        */

        if (Input.GetMouseButton(1) && ForceFieldEnergy != 0)
        {
            Instantiate(ForceField, ForceFieldPoint.position, ForceFieldPoint.rotation);
            ForceFieldEnergy -= Time.deltaTime;
        }
        else if (Input.GetMouseButton(1) && ForceFieldEnergy == 0)
        {
            //Logic goes here
            //May need to change where to put this script
        }

        
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
