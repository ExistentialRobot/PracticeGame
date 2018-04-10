using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBehavior : MonoBehaviour {
    public int healthCount;
    public float fade;
    public float safePeriod;
    public float opacity;
    public float fadeSpeed;
    public bool invincible;
    public bool fadeIn;
    public bool fadeOut = true;
    

	void Start ()
    {
		if(healthCount == 0)
        {
            healthCount = 4;
        }
	}
	
	void Update ()
    {
        gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, fade);
        opacity = gameObject.GetComponent<SpriteRenderer>().color.a;
        if (invincible == true)
        {    
            if(fadeOut == true)
            {
                fade -= .1f * fadeSpeed * Time.deltaTime;
                if(fade <= .3f)
                {
                    fadeOut = false;
                    fadeIn = true;
                }
            }
            if (fadeIn == true)
            {
                fade += .1f * fadeSpeed * Time.deltaTime;
                if (fade >= .8f)
                {
                    fadeOut = true;
                    fadeIn = false;
                }
            }
        }
        if(invincible == true)
        {
            StartCoroutine(IsImmortal());
        }
        if(invincible == false)
        {
            gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
        }
	}

    private void OnCollisionStay2D(Collision2D col)
    {
        if(col.gameObject.layer == 9)
        {
            if(col.gameObject.tag == "Monster")
            {
                if(invincible == false)
                {
                    healthCount -= 1;
                    invincible = true;
                    StartCoroutine(IsImmortal());
                }
            }
        }
    }
    IEnumerator IsImmortal()
    {
        yield return new WaitForSeconds(safePeriod);
        invincible = false;
    }
}
