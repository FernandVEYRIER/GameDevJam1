using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour {

	public GameObject bullet;
	public Transform startPos;
	public float bulletVelocity = 100F;
	public float bulletDelay = .2f;
	private float lastShot = -1;
	Transform playerScale;

	void Start()
	{
		playerScale = this.transform.GetComponentInParent<Transform>();
	}

	void Update () 
	{
		lastShot -= Time.deltaTime;
		if (lastShot < 0 && Input.GetButton("Fire1"))
		{
			lastShot = bulletDelay;
			GameObject go = (GameObject) Instantiate(bullet, startPos.position, Quaternion.identity);
			Debug.Log(this.transform.right);
			go.rigidbody2D.velocity = new Vector2(bulletVelocity * -playerScale.localScale.x, 0);
			Destroy(go, 2f);
		}
	}
}
