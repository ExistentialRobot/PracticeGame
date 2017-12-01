using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour {
    public GameObject player;
    public Text gameOver;

	void Start ()
    {
        gameOver.canvasRenderer.SetAlpha(0f);
    }
	
	void Update ()
    {
        if (player.activeSelf == false)
        {
            print("gameover");
            gameOver.CrossFadeAlpha(1.0f, 1.0f, true);
        }
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
	}
}
