// Simple script to play audio sounds when clicked on GUI
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlay : MonoBehaviour
{
	public AudioSource audioSource;
	public AudioClip audioClip;

	public void playClip()
	{
		audioSource.clip = audioClip;
		audioSource.Play();
	}
}
