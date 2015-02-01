using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DispScoreGameEnds : MonoBehaviour {

	void Start () 
	{
		this.GetComponent<Text>().text = "High Score : " + PlayerPrefs.GetInt("Score") + "\nYour score : " + GameManager.score;
	}
}
