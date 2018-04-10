using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMove : MonoBehaviour {
    public Vector3 monsterPosition;
    public Vector2 direction;
    public float yPos;
    public float rayLength = 2.5f;
    public Rigidbody2D rig;
    public Animator anim;
    public PlayerBehavior playerPos;
    public int inputH = 1;
    public float speed;
    public float runSpeed = 2.7f;
    RaycastHit2D hit;

    void Start ()
    {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

	void Update ()
    {
        Debug.DrawRay(monsterPosition, direction * rayLength, Color.green);
        hit = Physics2D.Raycast(monsterPosition, direction, rayLength, 1<<10);
        monsterPosition = transform.position;
        yPos = monsterPosition.y;
        if (inputH == 1)
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
            anim.Play("Monster_Walk_R");
            anim.SetBool("Walk", true);
            direction = Vector3.right;
        }
        if (inputH == -1)
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
            anim.Play("Monster_Walk_L");
            anim.SetBool("Walk", true);
            direction = Vector3.left;
        }
        if (inputH == 0)
        {
            anim.SetBool("Walk", false);
            transform.position += Vector3.zero;
            StartCoroutine(MoveReset());
        }
        if (hit.collider.tag == "Player" && inputH != 0)
        {
            gameObject.transform.position = Vector3.MoveTowards(monsterPosition, new Vector2(playerPos.xPos, yPos), runSpeed * Time.deltaTime);
            Debug.Log(hit.collider.name);
        }
    }
    IEnumerator MoveReset()
    {   
        yield return new WaitForSeconds(3);
        if (inputH == 0)
        {
            if (direction == Vector2.right)
            {
                inputH = -1;
                Debug.Log("Left");
                StopCoroutine(MoveReset());
            }
            else if (direction == Vector2.left)
            {
                inputH = 1;
                Debug.Log("Right");
                StopCoroutine(MoveReset());
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D col)
    {       
        if (col.gameObject.layer == 8)
        {
            if (col.gameObject.tag == "Boundary")
            {
                switch (inputH)
                {
                    case 1:
                        inputH = -1;
                        break;
                    case -1:
                        inputH = 1;
                        break;
                }
            }
        }
        if(col.gameObject.layer == 8 && hit.collider.tag == "Player")
        {
            inputH = 0;
        }
        if(col.gameObject.tag == "BounceShroom")
        {
            Physics2D.IgnoreCollision(gameObject.GetComponent<Collider2D>(), col.gameObject.GetComponent<Collider2D>());
        }
    }
}
