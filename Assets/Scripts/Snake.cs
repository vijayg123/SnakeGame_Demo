using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour {

	public Vector3 direction= Vector3.right;
	public float distanse = 2;
	public bool ate = false;
	List<Transform> trail = new List<Transform>();
	public GameObject[] trailPrefab;
	public Food foodRef;

	public delegate void OnGameOver();
	public event OnGameOver onGameOver;

	public UIHandler uiHandler;
	public TextParser parser;
	int colorStreak=0;
	string previousColor = string.Empty;
	bool isFirstTail = true;
	int tailcount =0;
	// Use this for initialization
	void Start () 
	{
		InvokeRepeating ("Move",.25f,.25f);
	}
	
	// Update is called once per frame
	void Update () 
	{
//		Move ();
	}

	void Move()
	{
		Vector3 v = transform.position;
		transform.Translate (direction*distanse);

		if (ate) {
			GameObject g = Instantiate (trailPrefab[foodRef.foodNumber], v, Quaternion.identity);
//			if (tailcount<10) {
//				g.name = "First";
//			}
			tailcount++;
			trail.Insert (0, g.transform);
			ate = false;
		} else if (trail.Count > 0)
		{
			trail [trail.Count - 1].position = v;
			trail.Insert (0, trail[trail.Count-1]);
			trail.RemoveAt (trail.Count-1);

		}
	}

	void OnTriggerEnter(Collider col)
	{
		if (col.name.Contains ("Boundary") )//|| col.name.Contains("Tail"))
		{
			gameObject.SetActive (false);
			Debug.Log ("Game Over");

			if (onGameOver != null)
				onGameOver();
		}

		if (col.name.Contains ("Food")) 
		{
			FoodItem item = col.gameObject.GetComponent<FoodItem> ();
			if (previousColor.Equals (item.foodColor))
				colorStreak++;
			else
				colorStreak = 1;

			foodRef.GenerateFood ();
			ate = true;
			Destroy (col.gameObject);
			Debug.Log ("Fooo Collected "+ col.name);
			uiHandler.UpdateScore (parser.colorScore[item.foodColor]*colorStreak);
			previousColor = item.foodColor;
		}
	}
}
