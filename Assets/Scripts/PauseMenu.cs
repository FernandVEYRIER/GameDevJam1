using UnityEngine;
using System.Collections;

public class PauseMenu : MonoBehaviour {

	GameObject PauseText;

	void Start () 
	{
		PauseText = this.transform.GetChild(0).gameObject;
		PauseText.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetButtonDown("Pause"))
		{
			PauseText.SetActive(true);
			Time.timeScale = 0;
		}
	}

	public void OnUnpause()
	{
		Time.timeScale = 1;
		PauseText.SetActive(false);
	}

	public void OnQuitButton()
	{
		Application.Quit();
	}
}
