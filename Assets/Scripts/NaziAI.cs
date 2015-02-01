using UnityEngine;
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
		if (lastShot < 0 && (vecDist.y <= 0.1 && vecDist.y >= -0.1))
		{
			lastShot = shootDelay;
			GameObject go = Instantiate(bulletPrefab, bulletStart.transform.position, Quaternion.identity) as GameObject;
			go.rigidbody2D.velocity = new Vector2(-bulletVelocity * this.transform.localScale.x, 0);
			Destroy(go, 3f);
		}
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.collider.tag == "Player")
		{
			GameManager.score += scoreReward;
			col.collider.GetComponent<LifeAndAmmo>().lifePoints -= 5;
			audio.PlayOneShot(deathSound, 10f);
			Destroy(Instantiate(bloodSplash, this.transform.position, Quaternion.identity), 2f);
			Destroy(Instantiate(helmetFall, this.transform.position, Quaternion.identity), 2f);
			Destroy(this.gameObject);
		}
	}
}
