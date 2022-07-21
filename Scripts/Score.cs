using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{

	public Transform playerPos;
	public GameObject player;
	public Text scoreText;
	private float score = 0;
	private float pointsToAdd;
	Vector3 currPos;

	void Start()
	{
		Vector3 currPos = player.transform.position;
	}
    // Update is called once per frame
    void Update()
    {
		Vector3 newPos = player.transform.position;
		// Score is based on how far you've travelled
		// Ensure points are only added if the Hero is running
		//if(player.GetComponent<Rigidbody>().velocity.magnitude > 0.1f)
		if(currPos != newPos)
		{
			pointsToAdd = ((Mathf.Abs(playerPos.position.x) + Mathf.Abs(playerPos.position.z)) * Time.deltaTime);
			score += pointsToAdd;
			currPos = newPos;
		}
        scoreText.text = score.ToString("0");
    }
}
