using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitButtonScript : MonoBehaviour
{
    //public string MainMenu;
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
        Debug.Log("The player has guit the game");
        Application.Quit();
    }

    private void OnMouseOver()
    {
        transform.localScale = new Vector3(ScaleSizeX, ScaleSizeY, 0);
    }
}
