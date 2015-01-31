using UnityEngine;
using System.Collections;

public class NaziShoot : MonoBehaviour {
	
	public float bulletVelocity;
	public GameObject bulletPrefab;
	public Transform bulletStart;
	public float shootDelay = 2;

	float lastShot = -1;
	GameObject player;

	void Start () 
	{
		player = GameObject.FindGameObjectWithTag("Player");
		float dist = Vector2.Distance(player.transform.position, this.transform.position);
		Debug.Log(dist);
	}
	
	void Update () 
	{
		lastShot -= Time.deltaTime;
		if (lastShot < 0)
		{
			lastShot = shootDelay;
			GameObject go = Instantiate(bulletPrefab, bulletStart.transform.position, Quaternion.identity) as GameObject;
			go.rigidbody2D.velocity = new Vector2(-bulletVelocity * this.transform.localScale.x, 0);
		}
	}
}
