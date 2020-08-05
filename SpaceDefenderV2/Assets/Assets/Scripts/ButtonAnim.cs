using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonAnim : MonoBehaviour
{
    
 
    public string SceneName;
    public float ScaleSizeX;
    public float ScaleSizeY;



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
        transform.localScale = new Vector3(ScaleSizeX, ScaleSizeY, 0);
        
    }

    private void OnMouseExit()
    {
        transform.localScale = new Vector3(2, 0.5f, 0);
    }

    private void OnMouseDown()
    {
        SceneManager.LoadScene(SceneName);
    }


    private void OnMouseOver()
    {
        transform.localScale = new Vector3(ScaleSizeX, ScaleSizeY, 0);
    }
}
