using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointBehavior : MonoBehaviour {
    Animator anim;
    public Player player;

	void Start ()
    {
        anim = GetComponent<Animator>();
	}

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            anim.Play("Checkpoint_Animation");
            if (!player.Checkpoints.Contains(gameObject))
            {
                player.Checkpoints.Insert(0, gameObject);
            }
        }
    }
}
