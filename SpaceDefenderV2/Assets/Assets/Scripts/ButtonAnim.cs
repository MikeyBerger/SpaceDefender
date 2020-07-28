using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonAnim : MonoBehaviour
{
    
    //public Transform Button;
    public float ScaleSize;
    public string SceneName;


    // Start is called before the first frame update
    void Start()
    {

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseEnter()
    {
        transform.localScale = new Vector3(5, 2.5f, 1) * ScaleSize;
        
    }

    private void OnMouseExit()
    {
        transform.localScale = new Vector3(10, 5, 1) / ScaleSize;
    }

    private void OnMouseDown()
    {
        SceneManager.LoadScene(SceneName);
    }
}
