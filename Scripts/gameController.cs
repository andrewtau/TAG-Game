using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameController : MonoBehaviour
{
	// Create public reference to animator
	public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
		// Press 1 to play the first animation
        if(Input.GetKeyDown("1"))
		{
			anim.Play("Baseball Hit");
		}

		// Press 2 to play the second animation
		if(Input.GetKeyDown("2"))
		{
			anim.Play("Hit To Body");
		}

		// Press 3 to play the third animation
		if(Input.GetKeyDown("3"))
		{
			anim.Play("Medium Hit To Head");
		}

		// Press 4 to play the fourth animation
		if(Input.GetKeyDown("4"))
		{
			anim.Play("Punch Combo");
		}

		// Press 5 to play the fifth animation
		if(Input.GetKeyDown("5"))
		{
			anim.Play("Standing Death Left 01");
		}

		// Press 6 to play the last animation
		if(Input.GetKeyDown("6"))
		{
			anim.Play("Wave Hip Hop Dance");
		}
    }
}
