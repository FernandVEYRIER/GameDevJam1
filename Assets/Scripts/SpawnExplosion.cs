﻿using UnityEngine;
using System.Collections;

public class SpawnExplosion : MonoBehaviour {

	public GameObject 		explosionPrefab;
	public int						damage;
	public GameObject	 	blastPrefab;
	public float 				radius = 3f;
	public AudioClip			explosionSound;

	void Start()
	{
		Invoke ("SpawnStuff", explosionSound.length);
	}

	//Grenade explosion
	void SpawnStuff()
	{
		//add sphere cast to destroy ennemies, and increase score
		GameObject go = (GameObject) Instantiate(explosionPrefab, this.transform.position, Quaternion.identity);
		Collider2D[] allCol = Physics2D.OverlapCircleAll(this.transform.position, radius);
		Debug.DrawLine(this.transform.position, this.transform.position + new Vector3(radius, 0, 0));
		Destroy(Instantiate(blastPrefab, this.transform.position, Quaternion.identity), 0.2f);
		foreach (Collider2D col in allCol)
		{
			if (col.GetComponent<Collider2D>().tag == "Enemy")
			{
				GameManager.score += 100;
				Destroy(col.GetComponent<Collider2D>().gameObject);
			}
			if (col.GetComponent<Collider2D>().tag == "Player")
			{
				GameObject.FindWithTag("Player").GetComponent<LifeAndAmmo>().lifePoints -= damage;
			}
			Destroy(this.gameObject);
		}
	}
}
