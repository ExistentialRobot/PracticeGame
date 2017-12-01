using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class detectCollision : MonoBehaviour {
    public playerMove script;
    public int score;
    public Values health;
    public GameObject coins;
    public AudioSource coinSound;
    public AudioSource damageSound;

    private void OnCollisionEnter2D(Collision2D col)
    {
        
        if(col.gameObject.layer == 8)
        {
            script.grounded = true;
            script.anim.SetBool("Grounded", true);
        }
        if(col.gameObject.tag == "Enemy" || col.gameObject.layer == 9)
        {
            damageSound.Play();
            if (health.health[0].activeSelf)
            {
                health.health[0].SetActive(false);
            }
            else if (health.health[1].activeSelf)
            {
                health.health[1].SetActive(false);
            }
            else if (health.health[2].activeSelf)
            {
                health.health[2].SetActive(false);
                gameObject.SetActive(false);
            }
        }  
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Collectable")
        {
            
            col.gameObject.SetActive(false);
            score = score + 1;
            coinSound.Play();
        }
        if(col.gameObject.layer == 11)
        {
            Physics2D.IgnoreCollision(gameObject.GetComponent<Collider2D>(), col.gameObject.GetComponent<Collider2D>());
        }
    }

}
