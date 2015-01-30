using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	GameObject player;
	public int score = 0;
	public Text lives;
	public Text scoreText;

	void Start () {

	}
	

	void Update () 
	{
		if (player == null)
		{
			player = GameObject.FindGameObjectWithTag("Player");
			return;
		}
		lives.text = player.GetComponent<LifeAndAmmo>().lifePoints + " /  100";
		scoreText.text = "Score : " + score.ToString(); 
	}

	public void addScore(int points)
	{
		score += points;
	}
}
