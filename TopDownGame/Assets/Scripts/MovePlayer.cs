using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour {
    public GameObject player;
    public float speed;
    public Vector3 pos;
    public Vector3 origin;
    public Vector2 direction;
    public Animator anim;
    public Movement movement;
    

	void Start ()
    {
        pos = player.transform.position;
        anim = player.GetComponent<Animator>();
        player.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {     
        if (Input.GetKeyUp(KeyCode.D))
        {
            anim.SetFloat("Blend", 0f);
            movement.scripts.SetActive(true);
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            anim.SetFloat("Blend", .35f);
            movement.scripts.SetActive(true);
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            anim.SetFloat("Blend", .65f);
            movement.scripts.SetActive(true);
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            anim.SetFloat("Blend", 1f);
            movement.scripts.SetActive(true);
        }
    }

    void FixedUpdate ()
    {
        RaycastHit2D hit = Physics2D.Raycast(player.transform.position, direction);
        hit.distance = .01f;
        if (Input.GetKey(KeyCode.D))
        {       
            direction = Vector2.right;
            Debug.Log(direction);
            if (player.transform.position == pos)
            {              
                if (direction == Vector2.right)
                {
                    if (hit.collider == false)
                    {
                        origin = pos;
                        pos += Vector3.right;
                    }
                }
                anim.Play("Walk_Right");
                anim.SetBool("Moving", true);
            }
        }
        if (Input.GetKey(KeyCode.A))
        {
            direction = Vector2.left;
            Debug.Log(direction);
            if (player.transform.position == pos)
            {
                if (direction == Vector2.left)
                {
                    if (hit.collider == false)
                    {
                        origin = pos;
                        pos += Vector3.left;
                    }
                }
                anim.Play("Walk_Left");
                anim.SetBool("Moving", true);
            }
        }
        if (Input.GetKey(KeyCode.W))
        {
            direction = Vector2.up;
            Debug.Log(direction);
            if (player.transform.position == pos)
            {
                if (direction == Vector2.up)
                {
                    if (hit.collider == false)
                    {
                        origin = pos;
                        pos += Vector3.up;
                    }
                }
                anim.Play("Walk_Up");
                anim.SetBool("Moving", true);
            }
        }
        if (Input.GetKey(KeyCode.S))
        {
            direction = Vector2.down;
            Debug.Log(direction);
            if (player.transform.position == pos)
            {
                if (direction == Vector2.down)
                {
                    if (hit.collider == false)
                    {
                        origin = pos;
                        pos += Vector3.down;
                    }
                }
                anim.Play("Walk_Down");
                anim.SetBool("Moving", true);
            }
        }
        if (player.transform.position != pos )
        {
            player.transform.position = Vector3.MoveTowards(player.transform.position, pos, speed * Time.deltaTime);
        }
    }
    
    //private void OnCollisionEnter2D(Collision2D collision)
    //{
       // if (collision.gameObject.tag == "Barrier")
        //{
          //  pos = origin;
            //player.transform.position = Vector3.MoveTowards(player.transform.position, origin, speed * Time.deltaTime);
            //Debug.Log("Collided");
        //}
    //}
}
