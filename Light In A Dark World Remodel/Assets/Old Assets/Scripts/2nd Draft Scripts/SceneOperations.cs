using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneOperations : MonoBehaviour {
    public GameObject platform;
    public GameObject parent;
    public float platSpacing;
    public float fallSpeed;

	void Start ()
    {
        StartCoroutine(FallingPlatforms());
	}
	
	void Update ()
    {
		
	}
    IEnumerator FallingPlatforms()
    {
        yield return new WaitForSeconds(platSpacing);
        Instantiate<GameObject>(platform, parent.transform);
        StartCoroutine(FallingPlatforms());
    }
}
