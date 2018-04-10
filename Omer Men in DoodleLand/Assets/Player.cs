using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    public float speed;
    public Animator anim;
    public Rigidbody2D rig;
    public int iDirection;
    public Vector3 fDirection;
    public Vector3 jumpHeight;
    public string direction;
    public Joystick move;

	void Start ()
    {
        anim = GetComponent<Animator>();
        rig = GetComponent<Rigidbody2D>();
	}
	
	void Update ()
    {
        iDirection = move.dir;
        if(iDirection == 1)
        {
            direction = "Right";
        }
        if(iDirection == -1)
        {
            direction = "Left";
        }
        //fDirection.x = Input.GetAxisRaw("Horizontal");
        //iDirection = Mathf.RoundToInt(fDirection.x);
        fDirection.x = iDirection;
        if(move.jump == true && anim.GetBool("Grounded") == true)
        {
            switch (direction)
            {
                case "Right":
                    anim.Play("OmerMan_Jump_R");
                    break;
                case "Left":
                    anim.Play("OmerMan_Jump_L");
                    break;
            }
            anim.SetBool("Grounded", true);
            rig.AddForce(jumpHeight, ForceMode2D.Impulse);
        }
        if(anim.GetBool("Grounded") == false)
        {
            switch (direction)
            {
                case "Right":
                    anim.Play("OmerMan_Jump_R");
                    break;
                case "Left":
                    anim.Play("OmerMan_Jump_L");
                    break;
            }
        }
        if (anim.GetBool("Grounded") == true)
        {
            switch (iDirection)
            {
                case 1:
                    anim.Play("OmerMan_Walk_R");
                    anim.SetBool("Moving", true);
                    break;
                case -1:
                    anim.Play("OmerMan_Walk_L");
                    anim.SetBool("Moving", true);
                    break;
                case 0:
                    anim.SetBool("Moving", false);
                    break;
            }
        }
        transform.position += fDirection * speed * Time.deltaTime; 
	}
    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Ground")
        {
            anim.SetBool("Grounded", true);
        }
    }
    private void OnCollisionExit2D(Collision2D col)
    {
        if(col.gameObject.tag == "Ground")
        {
            anim.SetBool("Grounded", false);
        }
    }
}
