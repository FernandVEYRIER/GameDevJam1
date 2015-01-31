﻿using UnityEngine;
using System.Collections;

public class NaziAI : MonoBehaviour {
	
	public float bulletVelocity;
	public GameObject bulletPrefab;
	public Transform bulletStart;
	public float shootDelay = 2;
	public int scoreReward = 100;
	public float moveSpeed = 100f;

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
		vecDist = player.transform.position - this.transform.position;
		leftBound = GameObject.Find("EndOfTerrainLeft").GetComponent<Transform>();
		rightBound = GameObject.Find("EndOfTerrainRight").GetComponent<Transform>();
	}
	
	void Update () 
	{
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
		this.rigidbody2D.velocity = new Vector2(-moveSpeed * this.transform.localScale.x, this.rigidbody2D.velocity.y);

		//shoot handling
		lastShot -= Time.deltaTime;
		if (lastShot < 0)
		{
			lastShot = shootDelay;
			GameObject go = Instantiate(bulletPrefab, bulletStart.transform.position, Quaternion.identity) as GameObject;
			go.rigidbody2D.velocity = new Vector2(-bulletVelocity * this.transform.localScale.x, 0);
		}
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.collider.tag == "Player")
		{
			GameManager.score += scoreReward;
			col.collider.GetComponent<LifeAndAmmo>().lifePoints -= 5;
			Destroy(this.gameObject);
		}
	}
}
