using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuUI : MonoBehaviour {

	public Text highScore;
	int lastScore=0;
	void Start()
	{ 
		

		UpdateHighScore ();
	}

	public void UpdateHighScore()
	{
		if (PlayerPrefs.GetInt ("LastScore") != null) 
		{
			if(PlayerPrefs.GetInt ("Score")>PlayerPrefs.GetInt ("LastScore"))
				PlayerPrefs.SetInt ("LastScore", PlayerPrefs.GetInt ("Score"));
		}
		else
			PlayerPrefs.SetInt ("LastScore", 0);

		if (PlayerPrefs.GetInt ("Score") != null)
		{   
			highScore.text = "High Score : " + PlayerPrefs.GetInt ("LastScore").ToString ();
		} 
		else
			highScore.text = "High Score : 0";
	}
	

}
