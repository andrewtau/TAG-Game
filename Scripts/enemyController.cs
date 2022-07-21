using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class enemyController : MonoBehaviour
{
	public GameObject sideEnemy1Prefab;
	public GameObject sideEnemy2Prefab;
	public GameObject sideEnemy3Prefab; 
	public GameObject GodOfSpeed;
	private GameObject enemy1;
	private GameObject enemy2;
	private GameObject enemy3;
	private GameObject godOfSpeed;
	public GameObject playerScore;
	private float maxSpeed = 10.0f;
	private float acceleration = 1.0f;
	private Vector3 spawnLocation;


    void Start()
    {
		spawnLocation = gameObject.transform.position;
		Spawn();
    }

	void Update()
	{
		Spawn(); // Constantly check if player's score has reached threshold for new enemy spawns
	}

	public void Spawn()
	{
		// Spawn this way to ensure only 1 enemy of each type is spawned
		// By Law of Speedforce: Time remnants are illegal!
		if(playerScore.GetComponent<heroController>().score >= 1000 && enemy1 == null)
		{
			// The Rival
			enemy1 = Instantiate(sideEnemy1Prefab, spawnLocation, Quaternion.identity);
		}
		else if(playerScore.GetComponent<heroController>().score >= 3000 && enemy2 == null)
		{
			// Zoom
			enemy2 = Instantiate(sideEnemy2Prefab, spawnLocation, Quaternion.identity);
		}
		else if(playerScore.GetComponent<heroController>().score > 6000 && enemy3 == null)
		{
			// Godspeed
			enemy3 = Instantiate(sideEnemy3Prefab, spawnLocation, Quaternion.identity);
		}
		else if(playerScore.GetComponent<heroController>().score > 10000 && godOfSpeed == null)
		{
			// Savitar
			godOfSpeed = Instantiate(GodOfSpeed, spawnLocation, Quaternion.identity);
		}
	}
}
