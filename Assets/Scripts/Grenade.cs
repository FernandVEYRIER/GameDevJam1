using UnityEngine;
using System.Collections;

public class Grenade : MonoBehaviour {

	public GameObject grenadePrefab;
	public Transform grenadeStart;
	public float grenadeVelocity = 10f;
	public float grenadeExplosionDelay = 3f;
	public float grenadeDelay = 3f;
	float lastThrow = -1;
	Transform playerScale;

	void Start()
	{
		playerScale = this.transform.GetComponentInParent<Transform>();
	}

	void Update () 
	{
		lastThrow -= Time.deltaTime;
		if (lastThrow < 0 && Input.GetButtonDown("Fire2"))
		{
			lastThrow = grenadeDelay;
			GameObject go = (GameObject) Instantiate(grenadePrefab, grenadeStart.position, Quaternion.identity);
			if (playerScale.localScale.x > 0)
				go.rigidbody2D.AddForce(grenadeStart.transform.right * -grenadeVelocity);
			else
				go.rigidbody2D.AddForce(grenadeStart.transform.up * grenadeVelocity);
			Destroy(go, grenadeExplosionDelay);
		}
	}
}
