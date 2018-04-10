using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour {
    public float inputH;
    public float speed;
    public float delay;
    public bool grounded;
    public bool softGrounded;
    public float rayDis;
    public float xPos;
    public float knockBack;
    public float force;
    public GameObject player;
    public Vector3 offset;
    public Vector3 jumpHeight;
    public Animator anim;
    public Rigidbody2D rig;
    public Operations op;
    public RaycastHit2D hit;
    public Vector3 targetLeft;
    public Vector3 targetRight;

	void Start ()
    {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
	
	void Update ()
    {
        knockBack = transform.position.x;
        xPos = gameObject.transform.position.x;
        Debug.DrawRay(transform.position + offset, Vector3.down * rayDis, Color.red);
        hit = Physics2D.Raycast(transform.position + offset, Vector3.down, rayDis, 1 << 8);
        anim.SetFloat("InputH", inputH);
        if (Time.timeScale != 0)
        {
            inputH = Input.GetAxisRaw("Horizontal");
        }
        if (inputH == 1)
        {
            rig.transform.position += Vector3.right * speed * Time.deltaTime;
            anim.SetBool("Right", true);
            anim.SetBool("Left", false);
        }
        if (inputH == -1)
        {
            rig.transform.position += Vector3.left * speed * Time.deltaTime;
            anim.SetBool("Right", false);
            anim.SetBool("Left", true);
        }
        if (Input.GetButtonDown("Jump") && grounded == true && hit.collider)
        {
            rig.AddForce(jumpHeight, ForceMode2D.Impulse);
            softGrounded = false;
        }
        Debug.Log(hit.collider.name);
    }

}
