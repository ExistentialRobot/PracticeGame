using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatforms : MonoBehaviour {
    public SceneOperations speed;
    public int fallDis;
    public Vector3 startLocal;
    public Vector3 endLocal;

    void Start()
    {
        startLocal = gameObject.transform.position;
    }

    void Update ()
    {
        endLocal = gameObject.transform.position;
        transform.position += Vector3.down * speed.fallSpeed * Time.deltaTime;
        if(endLocal.y < startLocal.y - fallDis)
        {
            gameObject.transform.DetachChildren();
            Destroy(gameObject);
        }
	}
    private void OnCollisionEnter2D(Collision2D col)
    {
        col.gameObject.transform.SetParent(transform);
    }
    private void OnCollisionExit2D(Collision2D col)
    {
        col.gameObject.transform.SetParent(null);
    }
}
