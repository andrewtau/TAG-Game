using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DespawnBolt : MonoBehaviour
{
	public GameObject hero;

	void OnCollisionEnter(Collision collision)
	{
		if(collision.gameObject.tag == "MainVillain" || collision.gameObject.tag == "SideVillain")
		{
			Destroy(gameObject);
		}
		else if(collision.gameObject.tag == "Hero")
		{
			Physics.IgnoreCollision(hero.GetComponent<Collider>(), GetComponent<Collider>(), true);
			GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0, 0, 350f));
			Destroy(gameObject, 5.0f); 
		}
		else
		{
			Destroy(gameObject, 5.0f);
		}
	}
}
