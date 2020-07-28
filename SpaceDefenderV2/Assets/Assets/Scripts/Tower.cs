using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public int Health;
    private int Damage;
    public Transform Explosion;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Damage = Random.Range(5, 15);

        if(Health <= 0)
        {
            Destroy(transform.gameObject);
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
            //Debug.Log("Tower was hit!");
            //Instantiate(Explosion, collision.gameObject.transform.position, collision.gameObject.transform.rotation);
            Destroy(collision.gameObject);

        }
    }
}
