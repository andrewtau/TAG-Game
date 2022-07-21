using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LineRendererMaker : MonoBehaviour
{
	LineRenderer lineRenderer;
	ArrayList points;
	public int maxPoints = 100;
	public float interval = 0.1f;

	float timer = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
    	lineRenderer = GetComponent<LineRenderer>();
		points = new ArrayList();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
		if(timer > interval)
		{
			timer = 0.0f;

			Vector3 pos = transform.position;
			points.Add(pos);

			if(points.Count > maxPoints)
			{
				points.RemoveAt(0);
			}

			lineRenderer.positionCount = points.Count;
			int i = 0;
			foreach(Vector3 v in points)
			{
				lineRenderer.SetPosition(i, v);
				i++;
			}
		}
    }

	// Changes the length of the linerenderer
	// Takes awhile to see change since every 
	// Update it cuts from the beginning
	public void AdjustLength(int newLength)
	{
		GameObject[] lines = GameObject.FindGameObjectsWithTag("Player");
		foreach (GameObject line in lines)
		{
			line.GetComponent<LineRendererMaker>().maxPoints += newLength;
		}
	}
}
