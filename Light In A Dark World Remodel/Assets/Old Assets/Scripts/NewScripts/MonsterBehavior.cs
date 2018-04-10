using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterBehavior : MonoBehaviour {
    public PlayerBehavior pos;
    public Vector3 direction;
    public string moveDirection = "Right";
    public string lastDirection;
    public float rayDis;
    public float speed;
    public float runSpeed;
    public float waitTime;
    public bool chase;
    public bool canChase;
    public Animator anim;
    RaycastHit2D hit;

	void Start ()
    {
        anim = GetComponent<Animator>();
        runSpeed = speed + 1;
	}
	
	void Update ()
    {
        if (anim.GetBool("Walk") == true && chase == false)
        {
            switch (moveDirection)
            {
                case "Right":
                    transform.position += Vector3.right * speed * Time.deltaTime;
                    direction = Vector3.right;
                    anim.Play("Monster_Walk_R");
                    anim.SetBool("Walk", true);
                    break;
                case "Left":
                    transform.position += Vector3.left * speed * Time.deltaTime;
                    direction = Vector3.left;
                    anim.Play("Monster_Walk_L");
                    anim.SetBool("Walk", true);
                    break;
                case null:
                    direction = Vector3.zero;
                    anim.SetBool("Walk", false);
                    break;
            }
        }
        hit = Physics2D.Raycast(gameObject.transform.position, direction, rayDis, 1 << 10);
        if(hit.collider != null)
        {
            chase = true;
            anim.SetBool("Walk", true);
            if (canChase == true)
            {
                transform.position = Vector3.MoveTowards(transform.position, new Vector3(pos.xPos, transform.position.y), runSpeed * Time.deltaTime);
            }
        }
        else if(hit.collider == null)
        {
            chase = false;
            StartCoroutine(FreezeMove());
        }
        Debug.DrawRay(gameObject.transform.position, direction * rayDis, Color.green);
        Debug.Log(hit.collider.tag);
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        lastDirection = moveDirection;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {

        if (chase == true)
        {
            canChase = false;
            if (hit.collider.tag == "Player")
            {
                moveDirection = null;
                if(hit.collider == null)
                {
                    StartCoroutine(FreezeMove());
                }
            } 
        }
        switch (moveDirection)
        {
            case "Right":
                moveDirection = "Left";
                break;
            case "Left":
                moveDirection = "Right";
                break;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        canChase = true;
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            moveDirection = null;
            StartCoroutine(FreezeMove());
        }
    }
    IEnumerator FreezeMove()
    {
        yield return new WaitForSeconds(waitTime);
        anim.SetBool("Walk", true);
        switch (lastDirection)
        {
            case "Right":
                lastDirection = "Left";
                moveDirection = lastDirection;
                break;
            case "Left":
                lastDirection = "Right";
                moveDirection = lastDirection;
                break;
        }
    }
}
