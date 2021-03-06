﻿using UnityEngine;
using System.Collections;

public class NaziAI : MonoBehaviour {
	
	public float bulletVelocity;
	public GameObject bulletPrefab;
	public Transform bulletStart;
	public float shootDelay = 2;
	public int scoreReward = 100;
	public float moveSpeed = 100f;
	public AudioClip deathSound;
	public GameObject bloodSplash;
	public GameObject helmetFall;
	[HideInInspector]
	public bool isOnFire = false;
	bool animOn = false;

	float lastShot = -1;
	float boundDistanceLeft;
	float boundDistanceRight;
	Vector2 vecDist;
	GameObject player;
	Transform leftBound;
	Transform rightBound;

	void Start () 
	{
		player = GameObject.FindGameObjectWithTag("Player");
		if (player == null)
			return;
		vecDist = player.transform.position - this.transform.position;
		leftBound = GameObject.Find("EndOfTerrainLeft").GetComponent<Transform>();
		rightBound = GameObject.Find("EndOfTerrainRight").GetComponent<Transform>();
	}
	
	void Update () 
	{
		if (player == null)
		{
			return;
		}
		if (isOnFire)
		{
			//run the other way
			if (!animOn)
				naziPanic();
			this.GetComponent<Rigidbody2D>().velocity = new Vector2(-moveSpeed * this.transform.localScale.x * 2, this.GetComponent<Rigidbody2D>().velocity.y);
			return;
		}
		//handle path
		vecDist = player.transform.position - this.transform.position;
		boundDistanceLeft =  Mathf.Abs (leftBound.position.x - this.transform.position.x);
		boundDistanceRight = Mathf.Abs(rightBound.position.x - this.transform.position.x);
		if ((vecDist.x > 0 && (vecDist.y <= 0.1 && vecDist.y >= -0.1)) || boundDistanceLeft < 0.5f)
		{
			this.transform.localScale = new Vector3(-1, this.transform.localScale.y, this.transform.localScale.z);
		}
		else if ((vecDist.x < 0 && (vecDist.y <= 0.1 && vecDist.y >= -0.1)) || boundDistanceRight < 0.5f)
		{
			this.transform.localScale = new Vector3(1, this.transform.localScale.y, this.transform.localScale.z);
		}
		this.GetComponent<Rigidbody2D>().velocity = new Vector2(-moveSpeed * this.transform.localScale.x, this.GetComponent<Rigidbody2D>().velocity.y);

		//shoot handling
		lastShot -= Time.deltaTime;
		if (lastShot < 0 && (vecDist.y <= 0.1 && vecDist.y >= -0.1))
		{
			lastShot = shootDelay;
			GameObject go = Instantiate(bulletPrefab, bulletStart.transform.position, Quaternion.identity) as GameObject;
			go.GetComponent<Rigidbody2D>().velocity = new Vector2(-bulletVelocity * this.transform.localScale.x, 0);
			Destroy(go, 3f);
		}
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.collider.tag == "Player")
		{
			GameManager.score += scoreReward;
			col.collider.GetComponent<LifeAndAmmo>().lifePoints -= 5;
			GetComponent<AudioSource>().PlayOneShot(deathSound, 10f);
			Destroy(Instantiate(bloodSplash, this.transform.position, Quaternion.identity), 2f);
			Destroy(Instantiate(helmetFall, this.transform.position, Quaternion.identity), 2f);
			Destroy(this.gameObject);
		}
	}

	void naziPanic()
	{
		this.transform.localScale = new Vector3(this.transform.localScale.x * -1, this.transform.localScale.y, this.transform.localScale.z);
		animOn = true;
	}
}
