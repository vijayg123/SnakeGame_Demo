using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextParser : MonoBehaviour {

	public TextAsset txtFile;
	public Dictionary<string,int> colorScore;
	// Use this for initialization
	void Start () {


		colorScore = new Dictionary<string, int> ();
		txtFile = Resources.Load ("Score") as TextAsset;
		if (txtFile == null)
			return;
		else 
		{
			string[] textData = txtFile.text.Split ('\n');
			for (int i = 0; i < textData.Length; i++)
			{
				string[] line = textData [i].Split (',');
				colorScore.Add (line [0], int.Parse (line [1]));
			}

		}

//		Debug.Log ("Score " + colorScore["green"]);
	}
	

}
