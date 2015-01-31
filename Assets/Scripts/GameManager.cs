using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	GameObject player;
	public static int score = 0;
	public Text lives;
	int livesCount;
	public Text scoreText;
	public Image lifeBar;
	public GameObject canvasMenu;
	public AudioClip deathSound;

	void Start()
	{
		score = 0;
	}

	void Update() 
	{
		if (player == null)
		{
			player = GameObject.FindGameObjectWithTag("Player");
			return;
		}
		livesCount = player.GetComponent<LifeAndAmmo>().lifePoints;
		lives.text = player.GetComponent<LifeAndAmmo>().lifePoints + " /  100";
		lifeBar.fillAmount = (float) livesCount / 100f;
		scoreText.text = "Score : " + score.ToString();
		if (livesCount <= 0 && !canvasMenu.activeSelf)
		{
			Destroy(player);
			audio.PlayOneShot(deathSound);
			GameObject.Find("CanvasPlayer").SetActive(false);
			canvasMenu.SetActive(true);
			if (PlayerPrefs.GetInt("Score") < score)
			{
				PlayerPrefs.SetInt("Score", score);
			}
		}
	}

	public void addScore(int points)
	{
		score += points;
	}

	public void OnFightClick()
	{
		Application.LoadLevel(Application.loadedLevel);
	}
}
