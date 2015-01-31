using UnityEngine;
using System.Collections;

public class MenuHandler : MonoBehaviour {

	public void OnPlayClick()
	{
		Application.LoadLevel(1);
	}

	public void OnQuitClick()
	{
		Application.Quit();
	}
}
