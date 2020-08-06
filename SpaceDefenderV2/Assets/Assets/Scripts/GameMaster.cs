using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMaster : MonoBehaviour
{
    private Transform Tower1;
    //private Transform Tower2;
    public string GameOverScene;


    // Start is called before the first frame update
    void Start()
    {
        Tower1 = GameObject.FindGameObjectWithTag("Tower1").GetComponent<Transform>();
        //Tower2 = GameObject.FindGameObjectWithTag("Tower2").GetComponent<Transform>();

    }

    // Update is called once per frame
    void Update()
    {
       

        if(Tower1 == null)
        {
            //Debug.LogError("IT'S GAME OVER MAN!!");
            SceneManager.LoadScene(GameOverScene);
        }

    }
}
