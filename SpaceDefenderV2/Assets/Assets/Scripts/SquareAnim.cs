using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareAnim : MonoBehaviour
{
    private SpriteRenderer SR;
    public Material NewMat;
    public Material DefaultMat;

    // Start is called before the first frame update
    void Start()
    {
        SR = GetComponent<SpriteRenderer>();
        SR.enabled = true;
        SR.sharedMaterial = SR.material;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseEnter()
    {
        SR.sharedMaterial = NewMat;
    }

    private void OnMouseExit()
    {
        SR.sharedMaterial = DefaultMat;
    }
}
