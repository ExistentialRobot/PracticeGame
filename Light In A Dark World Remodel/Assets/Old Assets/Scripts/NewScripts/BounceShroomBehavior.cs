using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceShroomBehavior : MonoBehaviour {
    Animator anim;
    public Vector3 bounceHeight;

    private void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            anim.Play("BounceShroom_Animation");
            col.gameObject.GetComponent<Rigidbody2D>().AddForce(bounceHeight, ForceMode2D.Impulse);
        }
    }
}
