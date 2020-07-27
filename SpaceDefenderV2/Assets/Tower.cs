using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public int TagNumber;

    // Start is called before the first frame update
    void Start()
    {
        TagNumber = Random.Range(1, 2);

        if(TagNumber == 1)
        {
            transform.gameObject.tag = ("Tower1"); 
        }else if (TagNumber == 2)
        {
            transform.gameObject.tag = ("Tower2");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
