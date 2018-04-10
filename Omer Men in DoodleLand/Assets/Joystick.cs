using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Joystick : MonoBehaviour {
    public Vector3 center;
    public Vector3 joyPos;
    public float floatOne;
    public float floatTwo;
    public float limit;
    public float distance;
    public float moveSpeed;
    public bool buttonPressed;
    public bool jump;
    public int dir;

	void Start ()
    {
        center = transform.localPosition;
	}
	
	void Update ()
    {
        floatOne = center.x;
        floatTwo = joyPos.x;
        joyPos = transform.localPosition;
        if (floatTwo > floatOne)
        {
            dir = 1;
        }
        if (floatTwo < floatOne)
        {
            dir = -1;
        }
        if (floatTwo == floatOne)
        {
            dir = 0;
        }
        if (buttonPressed == true && distance < limit)
        {
            transform.position = Vector3.MoveTowards(transform.position, Input.mousePosition, moveSpeed * Time.deltaTime);
        }
        distance = Vector3.Distance(center, transform.localPosition);
	}
    public void JoystickButton()
    {
        if (distance < limit)
        {
            buttonPressed = true;
        }
    }
    public void ResetJoyStick()
    {
        transform.localPosition = center;
        buttonPressed = false;
    }
    public void JumpButton()
    {
        switch (jump)
        {
            case true:
                jump = false;
                break;
            case false:
                jump = true;
                break;
        }
    }
}
