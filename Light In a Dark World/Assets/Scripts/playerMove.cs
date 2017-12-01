using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerMove : MonoBehaviour
{
    public GameObject player;
    public float speed;
    public float maxJump;
    public float jumpVelocity;
    public Vector3 jumpHeight;
    public Animator anim;
    public bool grounded;
    public bool rightButton;
    public bool leftButton;

    void Start()
    {
        anim = player.GetComponent<Animator>();
        grounded = true;
    }

    public void Update()
    {
        if (player.activeSelf)
        {
            jumpVelocity = Input.GetAxis("Vertical") * speed;
            anim.SetFloat("InputH", 0f);
            if (rightButton == true)
            {
                player.transform.position += Vector3.right * speed * Time.deltaTime;
                if (anim.GetBool("Grounded") == true)
                {
                    anim.Play("Walk_R");
                    anim.SetFloat("InputH", 1);
                }
            }
            if(leftButton == true)
            {
                player.transform.position += Vector3.left * speed * Time.deltaTime;
                if (anim.GetBool("Grounded") == true)
                {
                    anim.Play("Walk_L");
                    anim.SetFloat("InputH", -1);
                }
            }

        }       
    }

    public void Right()
    {
        leftButton = false;
        switch (rightButton)
        {
            case true:
                rightButton = false;
                break;
            case false:
                rightButton = true;
                break;
            default:
                rightButton = false;
                break;
        }
    }

    public void Left()
    {
        rightButton = false;
        switch (leftButton)
        {
            case true:
                leftButton = false;
                break;
            case false:
                leftButton = true;
                break;
            default:
                leftButton = false;
                break;
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
