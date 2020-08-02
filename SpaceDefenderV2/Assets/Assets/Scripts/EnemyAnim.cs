using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnim : MonoBehaviour
{
    private SpriteRenderer SR;
    public Material DamageMat;
    public Material DefaultMat;
    public float ChangeTimer;
    public int HitCount = 0;

    IEnumerator ResetColor()
    {
        yield return new WaitForSeconds(ChangeTimer);
        SR.sharedMaterial = DefaultMat;
    }

    // Start is called before the first frame update
    void Start()
    {
        SR = GetComponent<SpriteRenderer>();
        SR.enabled = true;
        SR.sharedMaterial = DefaultMat;
    }

    // Update is called once per frame
    void Update()
    {
        if(HitCount >= 4)
        {
            Destroy(transform.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if(collision.transform.gameObject.tag == "Bullet")
        {
            Debug.Log("Color Should Change!!!");
            SR.sharedMaterial = DamageMat;
            StartCoroutine(ResetColor());
            HitCount = HitCount + 1;
        }

    }

}
