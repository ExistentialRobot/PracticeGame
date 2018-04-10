using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving_Platform : MonoBehaviour {
    public Vector3 local;
    public Vector3 pointA;
    public Vector3 pointB;
    public Vector3 destination;
    public float speed;
    public GameObject Player;
    private EdgeCollider2D ground;

    void Start ()
    {   
        destination = pointA;
        ground = GetComponent<EdgeCollider2D>();
    }
	
	void Update ()
    {
        local = gameObject.transform.position;
        if (local == destination && destination == pointA)
        {
            destination = pointB;
        }
        else if(local == destination && destination == pointB)
        {
            destination = pointA;
        }
        transform.position = Vector3.MoveTowards(gameObject.transform.position, destination, speed * Time.deltaTime);
        if(Player.transform.position.y > transform.position.y + .5f)
        {
            ground.enabled = true;
        }
        else
        {
            ground.enabled = false;
        }
	}
    private void OnCollisionStay2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            col.gameObject.transform.SetParent(transform);
        }
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            col.gameObject.transform.SetParent(transform);
        }
    }
    private void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            col.gameObject.transform.SetParent(null);
        }
    }
}

