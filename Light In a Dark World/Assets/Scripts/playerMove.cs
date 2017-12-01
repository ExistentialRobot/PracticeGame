using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMove : MonoBehaviour
{
    public GameObject player;
    public float speed;
    public float maxJump;
    public float jumpVelocity;
    public Vector3 jumpHeight;
    public Animator anim;
    public bool grounded;

    void Start()
    {
        anim = player.GetComponent<Animator>();
        grounded = true;
    }

    void Update()
    {
        if (player.activeSelf)
        {
            jumpVelocity = Input.GetAxis("Vertical") * speed;
            anim.SetFloat("InputH", 0f);
    
        }
    }
    public void Right()
    {
            player.transform.position += Vector3.right * speed * Time.deltaTime;
            if (anim.GetBool("Grounded") == true)
            {
                anim.Play("Walk_R");
                anim.SetFloat("InputH", 1);
            }

    }
    public void Left()
    {
            player.transform.position += Vector3.left * speed * Time.deltaTime;
            if (anim.GetBool("Grounded") == true)
            {
                anim.Play("Walk_L");
                anim.SetFloat("InputH", -1);
            }
    }
    public void Jump()
    {
        if (grounded == true)
        {
            player.GetComponent<Rigidbody2D>().AddForce(jumpHeight, ForceMode2D.Impulse);
            anim.SetBool("Grounded", false);
            grounded = false;
        }
    }
}
