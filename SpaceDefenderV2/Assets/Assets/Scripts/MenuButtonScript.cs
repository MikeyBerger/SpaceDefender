using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtonScript : MonoBehaviour
{
    public string MainMenu;
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
        SceneManager.LoadScene(MainMenu);
    }

    private void OnMouseOver()
    {
        transform.localScale = new Vector3(ScaleSizeX, ScaleSizeY, 0);
    }


}
