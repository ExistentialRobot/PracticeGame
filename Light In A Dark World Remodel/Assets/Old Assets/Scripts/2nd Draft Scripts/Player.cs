using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    public float inputF;
    public int inputH;
    public float speed;
    public Vector3 direction;
    public Vector3 jumpHeight;
    public Animator anim;
    public Rigidbody2D rig;
    public RaycastHit2D hit;
    public float rayDis;
    public int direct;
    public bool affector;
    public List<GameObject> Checkpoints;
    public GameObject[] CheckpointsInLvl;
    public Vector3 startPos;
    public Vector3 spawnPoint;

	void Start ()
    {
        anim = GetComponent<Animator>();
        rig = GetComponent<Rigidbody2D>();
        startPos = transform.position;
	}
	
	void Update ()
    {
        hit = Physics2D.Raycast(transform.position, new Vector3(direct, 0, 0), rayDis, 1 << 8);
        anim.SetFloat("InputH", inputF);
        inputF = Input.GetAxisRaw("Horizontal");
        inputH = Mathf.RoundToInt(inputF);     
        switch (inputH)
        {
            case 1:
                direction = Vector3.right;
                anim.SetBool("Right", true);
                anim.SetBool("Left", false);
                direct = 1;
                break;
            case -1:
                direction = Vector3.left;
                anim.SetBool("Right", false);
                anim.SetBool("Left", true);
                direct = -1;
                break;
            case 0:
                direction = Vector3.zero;
                break;
        }
        if(Input.GetButtonDown("Jump"))
        {
            rig.AddForce(jumpHeight, ForceMode2D.Impulse);
        }

        if (hit.collider != null)
        {
            if (hit.collider.tag == "Player Limits")
            {
                speed = 0;
            }
        }
        else if (hit.collider == null && affector == false)
        {
            speed = 3;
        }
        CheckpointsInLvl = Checkpoints.ToArray();
        if (CheckpointsInLvl.Length == 0)
        {
            spawnPoint = startPos;
        }
        else
        {
            spawnPoint = CheckpointsInLvl[0].transform.position;
        }
        transform.position += direction * speed * Time.deltaTime;
        Debug.DrawRay(transform.position, new Vector3(direct, 0, 0) * rayDis, Color.red);
    }
    private void OnTriggerEnter2D(Collider2D trig)
    {
        if(trig.gameObject.tag == "Reset Zone")
        {
            transform.position = spawnPoint;
            rig.velocity = Vector3.zero;
        }
    }
}
