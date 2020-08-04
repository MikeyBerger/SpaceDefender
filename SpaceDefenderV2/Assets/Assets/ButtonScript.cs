using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour
{
    public float ScaleSize;
    
    //public Image ButtonImage;
 
    public string MainMenu;
    

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
        transform.localScale = transform.localScale * ScaleSize;
        
    }

    private void OnMouseExit()
    {
        transform.localScale = transform.localScale / ScaleSize;
        
    }

    private void OnMouseDown()
    {
        SceneManager.LoadScene(MainMenu);
    }
}
