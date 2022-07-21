using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningBolt : MonoBehaviour
{
	public GameObject boltPrefab;
	public GameObject energy;
	public float launchVelocity = 700f;
	public AudioSource projectileSource;
	public AudioClip projectileSound;

	void Start()
	{
		projectileSource.clip = projectileSound;
	}

	void Update()
	{
		if(Input.GetMouseButtonDown(0) && energy.GetComponent<Energy>().speedForce < 25)
		{
			Debug.Log("Not enough Speedforce generated!");
		}

		if(Input.GetMouseButtonDown(0) && energy.GetComponent<Energy>().speedForce >= 25)
		{
			Debug.Log("Lightning Bolt!");
			GameObject bolt = Instantiate(boltPrefab, transform.position, transform.rotation);
			bolt.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0, 0, launchVelocity));
			projectileSource.Play();
		}
	}
}
