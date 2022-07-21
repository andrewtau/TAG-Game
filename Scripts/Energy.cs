using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Energy : MonoBehaviour
{
	public GameObject player;
	public Text energyText;
	public float speedForce = 0;
	private float maxEnergy = 100;
	Vector3 currPos;

	void Start()
	{
		currPos = player.transform.position;
	}
    // Update is called once per frame
    void Update()
    {
		Vector3 newPos = player.transform.position;

		if(speedForce >= maxEnergy)
		{
			speedForce = 100;
		}

		if(speedForce <= 0)
		{
			speedForce = 0;
		}

		// Generate energy while running
		//if(player.GetComponent<Rigidbody>().velocity.magnitude > 0.1f)
		if(currPos != newPos)
		{
			if(player.GetComponent<heroController>().speed <= 10f)
			{
				speedForce += 3.0f * Time.deltaTime;
			}
			else if(player.GetComponent<heroController>().speed < 15f)
			{
				speedForce += 5.0f * Time.deltaTime;
			}
			else if(player.GetComponent<heroController>().speed >= 15f) // Hero will generate more Speedforce the faster they travel
			{
				speedForce += 10.0f * Time.deltaTime;
			}
			currPos = newPos;
		}

		if(Input.GetMouseButtonDown(0) && speedForce < 25)
		{
			Debug.Log("Not enough Speedforce generated!");
		}

		if(Input.GetMouseButtonDown(0) && speedForce >= 25)
		{
			speedForce -= 25f;
			Debug.Log("Lightning Bolt!");
		}


        energyText.text = speedForce.ToString("0");
    }
}
