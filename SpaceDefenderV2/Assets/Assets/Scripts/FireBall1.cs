using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall1 : MonoBehaviour
{
    public float Speed;
    public Transform Target;
    private Vector2 TargetVector;
    

    // Start is called before the first frame update
    void Start()
    {

       Target = GameObject.FindGameObjectWithTag("Tower1").GetComponent<Transform>();


       TargetVector = new Vector2(Target.position.x, Target.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, TargetVector, Speed * Time.deltaTime);


        if (Target == null)
        {
            Destroy(transform.gameObject);
        }

    }

    /*
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.transform.tag == "Tower1")
        {
            Debug.Log("Tower1 was hit");
        }

    }
    */
}
