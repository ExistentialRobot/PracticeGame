using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PlayerMove : MonoBehaviour {
    public Vector3 startPosition;
    public Vector3 playerPosition;
    public Vector2 jumpHeight;
    public Text scoreBoard;
    public float xPos;
    public float speed = 2.5f;
    public float InputH;
    public float delay;
    public bool grounded;
    public bool softGrounded;
    public int score;
    Rigidbody2D rig;
    Animator anim;
    public Animator animTwo;
    public GameObject[] hearts = new GameObject[4];
    public GameObject[] coins;
    public GameObject activeHeart;
    public GameObject lvlOver;
    public Touch touch;
    public Vector3 firstTouch;
    public Vector3 lastTouch;
    public bool left;
    public bool right;
    public int health = 4;
    public int topScore;
    public int finalScore;
    public bool inHazard;


    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        startPosition = transform.position;
        coins = GameObject.FindGameObjectsWithTag("Coin");
        topScore = coins.Length;
    }

    void Update()
    {
        scoreBoard.text = score.ToString();
        playerPosition = transform.position;
        xPos = playerPosition.x;
        //For pc testing
        if (Time.timeScale != 0)
        {
            InputH = Input.GetAxisRaw("Horizontal");
        }
        anim.SetFloat("InputH", InputH);
        if(score == topScore)
        {
            finalScore = score * health;
            lvlOver.SetActive(true);
        }
        //For android gameplay
        /*if (right == true && left == false)
        {
           rig.transform.position += Vector3.right * speed * Time.deltaTime;
            anim.SetBool("Right", true);
            anim.SetBool("Left", false);
        }
        if (left == true && right == false)
        {
            rig.transform.position += Vector3.left * speed * Time.deltaTime;
            anim.SetBool("Right", false);
            anim.SetBool("Left", true);
        }*/
        //For pc testing
        if (InputH == 1)
        {
            rig.transform.position += Vector3.right * speed * Time.deltaTime;
            anim.SetBool("Right", true);
            anim.SetBool("Left", false);
        }
        if (InputH == -1)
        {
            rig.transform.position += Vector3.left * speed * Time.deltaTime;
            anim.SetBool("Right", false);
            anim.SetBool("Left", true);
        }
        if (Input.GetButtonDown("Jump") && grounded == true)
        {
            rig.AddForce(jumpHeight, ForceMode2D.Impulse);
            softGrounded = false;
        }
        if (softGrounded == true)
        {
            StartCoroutine(DelayJump());
        }
        if (health == 0)
        {
            gameObject.transform.DetachChildren();
            gameObject.SetActive(false);
        }
        if (score >= topScore)
        {
            Time.timeScale = 0;
        }
        if (health == 3)
        {
            hearts[0].SetActive(false);
        }
        else if (health == 2)
        {
            hearts[1].SetActive(false);
        }
        else if (health == 1)
        {
            hearts[2].SetActive(false);
        }
        else if (health == 0)
        {
            hearts[3].SetActive(false);
        }
    }

    IEnumerator DelayJump()
    {
        yield return new WaitForSeconds(delay);
        if (softGrounded == true)
        {
            grounded = true;
        }
    }
    //For android gameplay
    /*public void Jump()
    {
        if (grounded == true)
        {
            rig.AddForce(jumpHeight, ForceMode2D.Impulse);
            softGrounded = false;
        }
    }*/
    public void Right()
    {
        switch (right)
        {
            case true:
                right = false;
                InputH = 0;
                break;
            case false:
                right = true;
                InputH = 1;
                break;
        }
    }
    public void Left()
    {
        switch (left)
        {
            case true:
                left = false;
                InputH = 0;
                break;
            case false:
                left = true;
                InputH = -1;
                break;
        }
    }
    private void OnCollisionStay2D(Collision2D col)
    {
        if (col.gameObject.layer == 8)
        {
            softGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.layer == 8)
        {
            softGrounded = false;
            grounded = false;
        }
        if(col.gameObject.tag == "Hazard")
        {
            inHazard = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.layer == 9)
        {
            Physics2D.IgnoreCollision(gameObject.GetComponent<Collider2D>(), col.gameObject.GetComponent<Collider2D>());
        }
        if (col.gameObject.layer == 10)
        {
            transform.position = startPosition;
            if (health > 1)
            {
                health -= 1;
            }
        }
        if (col.gameObject.layer == 13 && gameObject.tag == "Player")
        {
            col.gameObject.SetActive(false);
            score += 1;
        }
        if(col.gameObject.layer == 16)
        {
            animTwo.Play("Checkpoint_Animation");
        }
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.layer == 11)
        {
            health -= 1;
        }
        if (col.gameObject.tag == "Hazard")
        {
            inHazard = true;
            StartCoroutine(DecreaseHealth());
        }
    }
    IEnumerator DecreaseHealth()
    {  
        health -= 1;
        yield return new WaitForSeconds(1);
        if (inHazard)
        {
            StartCoroutine(DecreaseHealth());
        }
    }
}
