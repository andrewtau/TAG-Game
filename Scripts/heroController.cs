using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class heroController : MonoBehaviour
{
	public CharacterController controller;
	public Animator animator;
	public Transform cam;
	public float speed = 6f;
	public float turnSmoothTime = 0.1f;
	private float turnSmoothVelocity;
	private float acceleration = 3.0f;
	private float maxSpeed = 20.0f;
	public float score = 0;
	private float pointsToAdd;
	public int health = 100;
	private int randomEnemyLine;
	bool gameOver = false;


	void Start()
	{
		animator = GetComponent<Animator>();
	}
    // Update is called once per frame
    void Update()
    {
		pointsToAdd = ((Mathf.Abs(transform.position.x) + Mathf.Abs(transform.position.z)) * Time.deltaTime);
		score += pointsToAdd;
		Move();
		if(gameOver)
		{
			//SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Temporarily reset scene when game over
			// Ideally, return to main menu
			SceneManager.LoadScene("MainMenu");
		}
    }

	private void Move()
	{
		float horizontal = Input.GetAxisRaw("Horizontal");
		float vertical = Input.GetAxisRaw("Vertical");
		Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

		if(direction.magnitude >= 0.1f)
		{
			float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y; 
			float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
			transform.rotation = Quaternion.Euler(0f, targetAngle, 0f);

			Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
			controller.Move(moveDir.normalized * speed * Time.deltaTime);
			Walk();
		}
		if(direction.magnitude >= 0.1f && speed >= 10.0f)
		{
			Run();
		}

		if(direction.magnitude == 0f)
		{
			Idle();
		}
	}

	void OnCollisionEnter(Collision collisionInfo)
	{
		if(collisionInfo.collider.tag == "MainVillain")
		{
			Debug.Log("Not fast enough Flash!");
			health -= 10;
			if(health <= 0)
			{
				Debug.Log("GAME OVER");
				gameOver = true;
				health = 0;
			}
		}
		else if(collisionInfo.collider.tag == "SideVillain" || collisionInfo.collider.tag == "GodOfSpeed")
		{
			randomEnemyLine = Random.Range(1,3);
			if(randomEnemyLine == 1)
			{
				Debug.Log("I have no rival!");
			}
			else if(randomEnemyLine == 2)
			{
				Debug.Log("Remember! I am the fastest man alive!");
			}
			else if(randomEnemyLine == 3)
			{
				Debug.Log("I am the God of SPEED");
			}

			health -= 5;
			if(health <= 0)
			{
				Debug.Log("GAME OVER");
				gameOver = true;
				health = 0;
			}
		}
	}

	private void Idle()
	{
		speed = 6.0f;
		animator.SetFloat("minVel", 0, 0.1f, Time.deltaTime);
	}

	private void Walk()
	{
		speed += acceleration * Time.deltaTime;
		if(speed >= maxSpeed)
		{
			speed = maxSpeed;
		}
		animator.SetFloat("minVel", 0.5f, 0.1f, Time.deltaTime);
	}

	private void Run()
	{
		if(speed >= maxSpeed)
		{
			speed = maxSpeed;
		}
		animator.SetFloat("minVel", 1.0f, 0.1f, Time.deltaTime);
	}
}
