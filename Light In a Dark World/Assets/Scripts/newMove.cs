using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newMove : MonoBehaviour
{
    public GameObject player;
    public Rigidbody rig;
    public float speed = 2.5f;
    public Vector3 playerPos;
    public float InputH;
    public float InputV;
    public bool grounded;
    public bool jumpTwo;

    // Use this for initialization
    void Start()
    {
        rig = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        InputH = Input.GetAxisRaw("Horizontal");
        InputV = Input.GetAxisRaw("Vertical");
        if (Input.GetAxisRaw("Horizontal") != 0)
        {
            transform.position += Vector3.right * InputH * speed * Time.deltaTime;
        }
        if (Input.GetKeyDown(KeyCode.Space) && jumpTwo == false)
        {
            rig.AddForce(playerPos, ForceMode.Impulse);
            switch (grounded)
            {
                case true:
                    grounded = false;
                    break;
                case false:
                    jumpTwo = true;
                    break;
            }
        }

    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            grounded = true;
        }
        if (collision.gameObject.tag == "Wall")
        {
            grounded = false;
            jumpTwo = false;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            grounded = false;
            jumpTwo = false;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            grounded = true;
            jumpTwo = false;
        }
        if (collision.gameObject.tag == "Wall" && rig.velocity.x == 0f)
        {
            grounded = false;
        }
    }
}
