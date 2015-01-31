using UnityEngine;
using System.Collections;

public class Grenade : MonoBehaviour {

	public GameObject grenadePrefab;
	public Transform grenadeStart;
	public float grenadeVelocity = 10f;
	public float grenadeExplosionDelay = 3f;
	Transform playerScale;

	void Start()
	{
		playerScale = this.transform.GetComponentInParent<Transform>();
	}

	void Update () 
	{
		if (Input.GetButtonDown("Fire2"))
		{
			GameObject go = (GameObject) Instantiate(grenadePrefab, grenadeStart.position, Quaternion.identity);
			if (playerScale.localScale.x > 0)
				go.rigidbody2D.AddForce(grenadeStart.transform.right * -grenadeVelocity);
			else
				go.rigidbody2D.AddForce(grenadeStart.transform.up * grenadeVelocity);
			Debug.Log(grenadeStart.right);
			Destroy(go, grenadeExplosionDelay);
		}
	}
}
