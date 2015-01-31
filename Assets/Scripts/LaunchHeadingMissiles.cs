using UnityEngine;
using System.Collections;

public class LaunchHeadingMissiles : MonoBehaviour {

	public GameObject missilePrefab;
	public float missileVel = 30f;
	public float targetDelay = 3f;
	public float missileDelay = 30f;
	float lastShot = -1;
	bool warming = false;

	GameObject player;
	private SpriteRenderer thisSprite;

	void Start () 
	{
		this.transform.position = Camera.main.ScreenToWorldPoint(Vector3.zero) + new Vector3(.5f, 1f, 10);
		thisSprite = this.GetComponent<SpriteRenderer>();
		player = GameObject.FindGameObjectWithTag("Player");
		thisSprite.enabled = false;
	}
	

	void Update () 
	{
		lastShot -= Time.deltaTime;
		if (player == null)
			return;
		if (lastShot < 0)
		{
			thisSprite.enabled = true;
			this.transform.position = new Vector3
				(
					this.transform.position.x,
					player.transform.position.y
				);
			if (!warming)
			{
				warming =true;
				StartCoroutine(changeColors());
				Invoke("launchMissile", targetDelay);
			}
		}
	}

	void launchMissile()
	{
		lastShot= missileDelay;
		StartCoroutine(waitForLock());
	}

	IEnumerator waitForLock()
	{
		yield return new WaitForSeconds(0.5f);
		GameObject go = (GameObject) Instantiate(missilePrefab, this.transform.position, Quaternion.identity);
		go.rigidbody2D.velocity = new Vector2(missileVel, 0);
		Destroy(go, 10f);
		warming = false;
		thisSprite.enabled = false;
		StopAllCoroutines();
	}

	IEnumerator changeColors()
	{
		Debug.Log("here");
		int blueChannel = 0;
		int greenChannel = 0;
		SpriteRenderer sp = this.GetComponent<SpriteRenderer>();

		for (int i = 0; i < 666; i++)
		{
			sp.color = new Color(255, greenChannel, blueChannel);
			blueChannel = (blueChannel == 255) ? 0 : 255;
			greenChannel = (greenChannel == 255) ? 0 : 255;
			yield return new WaitForSeconds(.2f);
		}
	}
}
