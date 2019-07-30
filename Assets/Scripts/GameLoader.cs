using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameLoader : MonoBehaviour {



	// Use this for initialization
	void Start () {
		DontDestroyOnLoad (gameObject);
	}

	public void LoadGameScene()
	{
		SceneManager.LoadScene (1);
	}

	public void LoadStartScene()
	{
		SceneManager.LoadScene (0);

	}
		
}
