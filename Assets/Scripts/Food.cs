using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour {

	public GameObject[] food;
	public int foodNumber=0;
	public GameObject upBoundary, downBoundary, leftBoundary, rightBoundary;

	// Use this for initialization
	void Start () {
		
	}

	public void GenerateFood()
	{
		Vector3 pos = new Vector3(Random.Range (leftBoundary.transform.position.x+.4f,rightBoundary.transform.position.x-.4f),
			Random.Range (downBoundary.transform.position.y+.4f,upBoundary.transform.position.y-.4f),
		0f);
		foodNumber = Random.Range (0,food.Length);
		GameObject g = Instantiate (food[foodNumber], pos, Quaternion.identity);
		g.transform.parent = transform;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
