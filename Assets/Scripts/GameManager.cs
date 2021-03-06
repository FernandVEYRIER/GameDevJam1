﻿using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
	
	GameObject player;
	public static int score = 0;
	public Text lives;
	int livesCount;
	public Text scoreText;
	public Image lifeBar;
	public GameObject canvasMenu;
	public AudioClip deathSound;

	void Awake()
	{
		Application.targetFrameRate = 80;
	}

	void Start()
	{
		score = 0;
		SloMo.isSloMo = false;
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
			Time.timeScale = 1;
			Destroy(player);
			GetComponent<AudioSource>().PlayOneShot(deathSound);
			GameObject.Find("CanvasPlayer").SetActive(false);
			if (score > PlayerPrefs.GetInt("Score"))
			{
				PlayerPrefs.SetInt("Score", score);
			}
			canvasMenu.SetActive(true);
		}
	}
	
	public void addScore(int points)
	{
		score += points;
	}
	
	public void OnFightClick()
	{
		Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}
}