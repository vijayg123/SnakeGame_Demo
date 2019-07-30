using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHandler : MonoBehaviour {

	public Button buttonUp ,buttonDown,buttonLeft,buttonRight,continueButton;
	public Snake snake;
	public GameObject gameOverPopUp;
	public Text score,resultScore;
	int totalScore=0;
	// Use this for initialization
	void Start () 
	{
		buttonUp.onClick.AddListener(SetUpDirection);
		buttonDown.onClick.AddListener(SetDownDirection);
		buttonLeft.onClick.AddListener(SetLeftDirection);
		buttonRight.onClick.AddListener(SetRightDirection);
		continueButton.onClick.AddListener (StartScene);
		snake.onGameOver += ShowGameOverPopUp;
	}

	void SetUpDirection()
	{
		snake.direction = Vector3.up;
	}

	void SetDownDirection()
	{
		snake.direction = Vector3.down;
	}
	void SetLeftDirection()
	{
		snake.direction = Vector3.left;
	}
	void SetRightDirection()
	{
		snake.direction = Vector3.right;
	}

	public void ShowGameOverPopUp()
	{
		gameOverPopUp.SetActive (true);
		snake.onGameOver -= ShowGameOverPopUp;
		PlayerPrefs.SetInt ("Score",totalScore);
		resultScore.text = totalScore.ToString ();
	}

	public void StartScene()
	{
		GameObject.Find("GameLoader").GetComponent<GameLoader>().LoadStartScene();
	}

	public void UpdateScore(int value)
	{
		totalScore += value;
		score.text = totalScore.ToString ();
	}
	// Update is called once per frame
//	void Update () {
//		
//	}
}
