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
            if (!PauseText.activeSelf)
            {
                PauseText.SetActive(true);
                Time.timeScale = 0;
            }
            else
                OnUnpause();
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
