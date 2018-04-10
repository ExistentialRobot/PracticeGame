using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlastBehavior : MonoBehaviour {
    public float speed;
    public float blastDistance;


	void Start ()
    {
        StartCoroutine(Distance());
	}
	

	void Update ()
    {
        transform.position += Vector3.right * speed * Time.deltaTime;
	}
    IEnumerator Distance()
    {
        yield return new WaitForSeconds(blastDistance);
        Destroy(gameObject);
    }
}
