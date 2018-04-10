using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbBehavior : MonoBehaviour {
    private Rigidbody2D rig;
    public Vector3 newMove;
    public Vector3 movePoint;
    public Player player;
    public float speed;
    public float waitTime;
    public float radius;

	void Start ()
    {
        rig = GetComponent<Rigidbody2D>();
        StartCoroutine(ResetMovePoint());
	}
	
	void Update ()
    {
        rig.transform.position = Vector3.MoveTowards(transform.position, newMove, speed * Time.deltaTime);
	}
    IEnumerator NewMovePoint()
    {
        yield return movePoint;
        movePoint = Random.insideUnitCircle * radius;
        newMove = movePoint + transform.position;
        StartCoroutine(ResetMovePoint());
    }
    IEnumerator ResetMovePoint()
    {
        yield return new WaitForSeconds(waitTime);
        StartCoroutine(NewMovePoint());
    }
}
