using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monsterScript : MonoBehaviour {
    public bool turn;
    public float speed;
    public Animator anim;

	void Start ()
    {
		
	}

	void Update ()
    {
        switch (turn)
        {
            case true:
                gameObject.transform.position += Vector3.right * speed * Time.deltaTime;
                anim.Play("MonsterWalk_R");
                break;
            case false:
                gameObject.transform.position += Vector3.left * speed * Time.deltaTime;
                anim.Play("MonsterWalk_L");
                break;
        }
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.layer == 11)
        {
            switch (turn)
            {
                case true:
                    turn = false;
                    break;
                case false:
                    turn = true;
                    break;
            }
        }
    }
}
