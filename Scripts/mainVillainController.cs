using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class mainVillainController : MonoBehaviour
{
	public GameObject mainEnemyPrefab; // Can only be 1 main villain on the scene at a time
	private Vector3 spawnLocation;
	private float maxSpeed = 15.0f;
	private float acceleration = 2.0f;
	private NavMeshAgent enemy;

	public GameObject player;
	public float enemyDistanceRun = 4.0f;

    // Start is called before the first frame update
    void Awake()
    {
		spawnLocation = gameObject.transform.position;
		enemy = GetComponent<NavMeshAgent>();
		var mainVillan = Instantiate(mainEnemyPrefab, spawnLocation, Quaternion.identity);

		mainEnemyPrefab = GameObject.FindWithTag("MainVillain");
		if(mainEnemyPrefab != null)
		{
			Destroy(gameObject); // Should only be one main villain in the game at a time
		}
		else
		{
			mainVillan = Instantiate(mainEnemyPrefab, spawnLocation, Quaternion.identity);
		}
    }
}
