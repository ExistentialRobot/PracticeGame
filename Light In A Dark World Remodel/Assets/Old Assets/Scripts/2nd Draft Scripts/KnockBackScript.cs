using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockBackScript : MonoBehaviour {
    public Vector3 knockDirR;
    public Vector3 knockDirL;
    public Player movement;
    public Player myBool;
    public float delay;

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            myBool.affector = true;
            if (col.gameObject.transform.position.x > gameObject.transform.position.x)
            {
                col.gameObject.GetComponent<Rigidbody2D>().AddForce(knockDirR, ForceMode2D.Impulse);
                movement.speed = 0;
                StartCoroutine(moveDelay());
            }
            if (col.gameObject.transform.position.x < gameObject.transform.position.x)
            {
                col.gameObject.GetComponent<Rigidbody2D>().AddForce(knockDirL, ForceMode2D.Impulse);
                movement.speed = 0;
                StartCoroutine(moveDelay());
            }
        }
    }
    IEnumerator moveDelay()
    {
        yield return new WaitForSeconds(delay);

        movement.speed = 3;
        myBool.affector = false;
    }
}
