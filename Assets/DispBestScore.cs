using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DispBestScore : MonoBehaviour {

	// Use this for initialization
	void Start () 
	{
		this.GetComponent<Text>().text = "Best : " + PlayerPrefs.GetInt("Score");
	}

}
