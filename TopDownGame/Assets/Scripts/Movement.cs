using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {
    public MovePlayer move;
    public GameObject scripts;

	void Start ()
    {
		
	}
	
	void Update ()
    {
		if(move.player.transform.position == move.pos)
        {
            move.anim.SetBool("Moving", false);
            scripts.SetActive(false);
        }
	}
}
