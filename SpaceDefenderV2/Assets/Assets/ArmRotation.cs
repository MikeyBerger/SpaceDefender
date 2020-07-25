using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmRotation : MonoBehaviour
{
    public float Offset;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 Difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        Difference.Normalize();
        float RotZ = Mathf.Atan2(Difference.y, Difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, RotZ + Offset);
    }
}
