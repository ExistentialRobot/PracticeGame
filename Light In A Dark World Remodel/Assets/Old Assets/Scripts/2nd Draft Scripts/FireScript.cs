using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireScript : MonoBehaviour {
    public GameObject blast;
    public bool hasFired;
    public float waitTime;

	void Start ()
    {
		
	}
	
	void Update ()
    {
		if(Input.GetKeyDown(KeyCode.E) && hasFired == false)
        {
            hasFired = true;
            StartCoroutine(FireRate());
        }
	}
    IEnumerator FireRate()
    {
        Instantiate(blast);
        yield return new WaitForSeconds(waitTime);
        hasFired = false;
        StopCoroutine(FireRate());
    }
}
