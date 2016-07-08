using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuHandler : MonoBehaviour {

	public void OnPlayClick()
	{
        SceneManager.LoadScene(1);
	}

	public void OnQuitClick()
	{
		Application.Quit();
	}
}
