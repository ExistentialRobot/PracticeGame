using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipBehavior : MonoBehaviour {
    public float speed;
    public float rotateSpeed;
    public float maxSpeed;
    public float excel;
    public float brakesCurrent;
    public float brakesSet;
    public bool isMoving;
    public Rigidbody2D rig;
    public GameObject thruster;
    public Vector3 direction;
    public int inputH;
    public float inputF;

	void Start ()
    {
        rig = GetComponent<Rigidbody2D>();
	}
	
	void Update ()
    {
        inputF = Input.GetAxisRaw("Horizontal");
        inputH = Mathf.RoundToInt(inputF);
        switch (inputH)
        {
            case 1:
                transform.Rotate(Vector3.back * rotateSpeed * Time.deltaTime);
                break;
            case -1:
                transform.Rotate(Vector3.forward * rotateSpeed * Time.deltaTime);
                break;
            case 0:
                transform.Rotate(Vector3.zero);
                break;

        }
        if (Input.GetKey(KeyCode.W) && speed < maxSpeed)
        {
            isMoving = true;
            speed += excel * Time.deltaTime;
        }
        if(Input.GetKey(KeyCode.S) && isMoving == false)
        {
            brakesCurrent = brakesSet;
        }
        if(Input.GetKeyUp(KeyCode.S))
        {
            brakesCurrent = 0;
        }
        if(Input.GetKeyUp(KeyCode.W))
        {
            isMoving = false;
        }
        if(isMoving == false && speed > 0)
        {
            speed -= 3 * brakesCurrent * Time.deltaTime;
        }
        if(speed < 0)
        {
            speed = 0;
        }

        transform.Translate(0, 1 * speed * Time.deltaTime, 0, Space.Self);
	}
}
