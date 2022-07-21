using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
	public GameObject playerInfo;
	public Text healthText;
	private int randomEnemyLine;
	

    // Update is called once per frame
    void Update()
    {
        healthText.text = playerInfo.GetComponent<heroController>().health.ToString("0");
    }
}
