using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeBugBehavior : MonoBehaviour {
    public string moveDir;
    public float speed;
    public float viewDis;
    public RaycastHit2D limit;
    public RaycastHit2D view;
    public float viewDir;
    public Vector3 direction;
    public Animator anim;
    public GameObject player;

	void Start ()
    {
        moveDir = "Right";
        anim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
	}
	
	void Update ()
    {
        view = Physics2D.Raycast(new Vector3(transform.position.x + viewDir, transform.position.y, transform.position.z), direction, viewDis, 1 << 10);
        limit = Physics2D.Raycast(new Vector3(transform.position.x + viewDir, transform.position.y, transform.position.z), direction, viewDis, 1<<8);
        if (moveDir == "Right")
        {
            direction = Vector3.right;
            anim.Play("SpikeBug_R");
            transform.position += Vector3.right * speed * Time.deltaTime;

        }
        if (moveDir == "left")
        {
            direction = Vector3.left;
            anim.Play("SpikeBug_L");
            transform.position += Vector3.left * speed * Time.deltaTime;
        }
        if(limit.collider.tag == "Boundary")
        {
            switch (moveDir)
            {
                case "Right":
                    moveDir = "left";
                    viewDir = -1f;
                    break;
                case "left":
                    moveDir = "Right";
                    viewDir = 1f;
                    break;
                default:
                    break;
            }
        }
        Debug.Log(limit.collider.tag);
        Debug.DrawRay(new Vector3(transform.position.x + viewDir, transform.position.y, transform.position.z), direction * viewDis, Color.green);
    }

}
