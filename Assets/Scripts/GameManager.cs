using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	GameObject player;
	public static int score = 0;
	public Text lives;
	public Text scoreText;
	public Image lifeBar;

	void Update() 
	{
		if (player == null)
		{
			player = GameObject.FindGameObjectWithTag("Player");
			return;
		}
		lives.text = player.GetComponent<LifeAndAmmo>().lifePoints + " /  100";
		lifeBar.fillAmount = (float)player.GetComponent<LifeAndAmmo>().lifePoints / 100f;
		scoreText.text = "Score : " + score.ToString(); 
	}

	public void addScore(int points)
	{
		score += points;
	}
}
