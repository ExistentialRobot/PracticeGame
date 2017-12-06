using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour {
    public GameObject player;
    public Sprite[] face = new Sprite[4];
    public float speed;
    public Vector3 pos;
    public Animator anim;
    public bool keyPress;
    public Movement movement;
    public SpriteRenderer sprite;
    

	void Start ()
    {
        pos = player.transform.position;
        anim = player.GetComponent<Animator>();
        sprite = player.GetComponent<SpriteRenderer>();
    }
	
	void FixedUpdate ()
    {
        if(Input.GetKey(KeyCode.D))
        {
            if (player.transform.position == pos)
            {
                pos += Vector3.right;
                anim.Play("Walk_Right");
                anim.SetBool("Moving", true);
            }
        }
        if (Input.GetKey(KeyCode.A))
        {

            if (player.transform.position == pos)
            {
                pos += Vector3.left;
                anim.Play("Walk_Left");
                anim.SetBool("Moving", true);
            }
        }
        if (Input.GetKey(KeyCode.W))
        {

            if (player.transform.position == pos)
            {           
                pos += Vector3.up;
                anim.Play("Walk_Up");
                anim.SetBool("Moving", true);
            }
        }
        if (Input.GetKey(KeyCode.S))
        {

            if (player.transform.position == pos)
            {   
                pos += Vector3.down;
                anim.Play("Walk_Down");
                anim.SetBool("Moving", true);
            }
        }
        player.transform.position = Vector3.MoveTowards(player.transform.position, pos, speed * Time.deltaTime);
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
}
