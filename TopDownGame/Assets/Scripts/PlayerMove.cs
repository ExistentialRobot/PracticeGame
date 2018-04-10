using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {
    Animator anim;
    Rigidbody2D rig;
    public Vector2 vec;
    public Vector2 cel;
    public Vector2 origin;
    public Vector2 direction;
    public float speed = 2.5f;
    public float inputH;
    public float inputV;
    public LayerMask mask;
    public GameObject player;

	void Start ()
    {
        anim = player.GetComponent<Animator>();
        rig = gameObject.GetComponent<Rigidbody2D>();
        vec = rig.transform.position;
        cel = vec;
	}
	
	void Update ()
    {
        inputH = Input.GetAxis("Horizontal");
        inputV = Input.GetAxis("Vertical");
        vec = rig.transform.position;

        if(inputH == 0 && inputV == 0 && vec == cel)
        {
            anim.SetBool("Moving", false);
        }
        if (Input.GetKey(KeyCode.A))
        {
            if (vec == cel)
            {
                direction = Vector2.left;
                cel.x -= 1;
                anim.Play("Walk_Left");
                anim.SetFloat("Blend", .35f);
                anim.SetBool("Moving", true);
            }
        }
        if (Input.GetKey(KeyCode.D))
        {
            if (vec == cel)
            {
                direction = Vector2.right;
                cel.x += 1;
                anim.Play("Walk_Right");
                anim.SetFloat("Blend", 0f);
                anim.SetBool("Moving", true);
            }
        }
        if (Input.GetKey(KeyCode.S))
        {
            if (vec == cel)
            {
                direction = Vector2.down;
                cel.y -= 1;
                anim.Play("Walk_Down");
                anim.SetFloat("Blend", 1f);
                anim.SetBool("Moving", true);
            }
        }
        if (Input.GetKey(KeyCode.W))
        {
            if (vec == cel)
            {
                direction = Vector2.up;
                cel.y += 1;
                anim.Play("Walk_Up");
                anim.SetFloat("Blend", .65f);
                anim.SetBool("Moving", true);
            }           
        }
        RaycastHit2D hit = Physics2D.Raycast(rig.transform.position, direction, .5f, mask);
        if(hit.collider != null)
        {
            Debug.Log("Hit");
        }
        if (vec != cel)
        {
            if (hit.collider == null)
            {
                origin = cel;
                rig.transform.position = Vector2.MoveTowards(rig.transform.position, cel, speed * Time.deltaTime);
            }
            else if(hit.collider != null)
            {
                cel = origin;
            }
        }
	}
}
