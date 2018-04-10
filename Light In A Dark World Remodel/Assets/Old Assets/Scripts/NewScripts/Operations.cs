using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Operations : MonoBehaviour {
    public List<GameObject> collectedCoins;
    public GameObject[] coins;
    public List<GameObject> Checkpoints;
    public GameObject[] CheckpointsInLvl;
    public GameObject player;
    public Vector3 playerStart;
    public Vector3 spawnPoint;
    public int score;

	void Start ()
    {
        playerStart = player.transform.position;
        coins = GameObject.FindGameObjectsWithTag("Coin");
	}
	
	void Update ()
    {
        CheckpointsInLvl = Checkpoints.ToArray();
        if (CheckpointsInLvl.Length == 0)
        {
            spawnPoint = playerStart;
        }
        else
        {
            spawnPoint = CheckpointsInLvl[0].transform.position;
        }
	}
}
