using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioEffectController : MonoBehaviour {

  //  public GameObject scaleObject;
    public float scaleCoefficient = 10.0f;
    public AudioSource audioSource;
	public int numBands = 8;
    int qsamples = 512;
    //float previousSum = 0.0f;
    //public Color onColor;
    //public Color offColor;

    float[] samples;
	float[] freqBands; // Changed this 
    //float[] freqBands = new float[8];
    //bool active = true;

    public GameObject[] freqBandObjects;
	// Use this for initialization
	void Start () {
        samples = new float[qsamples];
		freqBands = new float[numBands]; // Initialize here to allow for more than 8
	}
	
	// Update is called once per frame
	void Update () {
        float sum = 0.0f;
     

            audioSource.GetSpectrumData(samples, 0, FFTWindow.Hamming);
            int count = 0;
            for (int i = 0; i < freqBands.Length; i++)
            {
                float average = 0;
				int sampleCount = i * 2;
                //int sampleCount = (int)Mathf.Pow(2, i) * 2;
                if (sampleCount == 0)
                {
					sampleCount = 1;
                    //sampleCount += 2;
                }
                for (int j = 0; j < sampleCount; j++)
                {
                    average += samples[count] * (count + 1);
                    count++;
                }
                average /= count;
                freqBands[i] = average;
            }

            for (int i = 0; i < freqBands.Length; i++)
            {
                sum += freqBands[i];
                  freqBandObjects[i].transform.localScale = new Vector3(1, freqBands[i] * scaleCoefficient, 1);
            }

    }
}
