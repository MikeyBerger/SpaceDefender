using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RetryButtonScript : MonoBehaviour
{
    public float ScaleSizeX;
    public float ScaleSizeY;
    
    //public Image ButtonImage;
 
    public string GameScene;

    

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnMouseEnter()
    {
        transform.localScale = new Vector3(ScaleSizeX, ScaleSizeY, 0);
        //Rect.localScale = new Vector3(ScaleSize, ScaleSize, 0);

    }

    public void OnMouseExit()
    {
        transform.localScale = new Vector3(2, 0.5f, 0);
        //Rect.localScale = new Vector3(1, 1, 0);

    }

    public void OnMouseDown()
    {
        SceneManager.LoadScene(GameScene);
    }

    private void OnMouseOver()
    {
        transform.localScale = new Vector3(ScaleSizeX, ScaleSizeY, 0);
    }

    /*
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Mouse")
        {
            transform.localScale = new Vector3(ScaleSize, ScaleSize, 0);
            Rect.localScale = new Vector3(ScaleSize, ScaleSize, 0);
        }
    }
    */
}
