using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Values : MonoBehaviour {
    public float timer;
    public Text displayScore;
    public Text displayTime;
    public detectCollision scoreCount;
    public GameObject[] objects;
    public GameObject[] hearts;
    public List<GameObject> health;

    void Start ()
    {
        hearts = GameObject.FindGameObjectsWithTag("Health");
        health.AddRange(hearts);
	}
	
	void Update ()
    {
        objects = GameObject.FindGameObjectsWithTag("Collectable");      
        displayScore.text = scoreCount.score.ToString();
        displayTime.text = timer.ToString("F2");
        if(objects.Length == 0)
        {
            Debug.Log("Winner");
        }
        if(scoreCount.isActiveAndEnabled)
        {
            timer = Time.realtimeSinceStartup;
        }
        else
        {
            Time.timeScale = 0f;
        }
    }
}
