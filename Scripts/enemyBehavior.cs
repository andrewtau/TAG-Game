using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemyBehavior : MonoBehaviour
{
	public Transform myTransform;
	public GameObject playerScore;
	public float enemySpeed = 10.0f;
	public Animator animator;
	private GameObject[] Hero;
	Vector3 currPos;
	bool isStunned = false;
	private float scoreThreshold = 8000;

	void Start()
	{
		Hero = GameObject.FindGameObjectsWithTag("Hero");
		currPos = gameObject.transform.position;
	}

	void Update()
	{
		if(!isStunned)
		{
			Move();
		}
		if(playerScore.GetComponent<heroController>().score >= scoreThreshold) // Gradually increase difficulty based on player's score
		{
			incSpeed();
			scoreThreshold += 2000;
		}
	}

	private void Move()
	{
		foreach(GameObject p in Hero)
		{
			transform.LookAt(p.transform.position);
			transform.Translate(Vector3.forward * enemySpeed * Time.deltaTime);
		}
		Vector3 newPos = gameObject.transform.position;
		if(currPos != newPos)
		{
			Run();
		}

		else if(currPos == newPos)
		{
			Idle();
		}
	}

	void OnCollisionEnter(Collision collision)
	{
		if(collision.gameObject.tag == "LightingBolt")
		{
			isStunned = true;
			StartCoroutine(Stun());
		}
	}
	private void Run()
	{
		animator.SetFloat("minVel", 1.0f, 0.1f, Time.deltaTime);
	}

	private void Idle()
	{
		animator.SetFloat("minVel", 0, 0.1f, Time.deltaTime);
	}

	private void incSpeed()
	{
		enemySpeed += 1.0f;
	}

	// Temporarily Stuns the target, causing them to run in a straight line
	IEnumerator Stun()
	{
		Debug.Log("Stunned!");
		transform.Translate(Vector3.forward * 0);
		yield return new WaitForSeconds(5);
		isStunned = false;
	}
}
