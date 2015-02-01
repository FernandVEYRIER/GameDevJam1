using UnityEngine;
using System.Collections;

public class DropCrates : MonoBehaviour {

	public GameObject [] crates;
	public float minWait = 20f;
	public float maxWait = 30f;
	float rightLimit;
	float leftLimit;
	bool goingLeft;

	private bool drop = false;

	void Start ()
	{
		this.transform.position = new Vector2(0, Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height, 0)).y);
		leftLimit = Camera.main.ScreenToWorldPoint(Vector3.zero).x;
		rightLimit = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)).x;
		goingLeft = true;
		StartCoroutine(dropCrate());
	}
	

	void Update () 
	{
		if (goingLeft)
		{
			this.transform.Translate(new Vector3(-2f, 0, 0) * Time.deltaTime);
		}
		else
		{
			this.transform.Translate(new Vector3(2f, 0, 0) * Time.deltaTime);
		}
		if (this.transform.position.x < leftLimit)
		{
			goingLeft = false;
		}
		else if (this.transform.position.x > rightLimit)
		{
			goingLeft = true;
		}
		if (drop)
		{
			Debug.Log("spawn");
			//destroy randomly
		}
	}

	IEnumerator dropCrate()
	{
		while (true)
		{
			drop = false;
			yield return new WaitForSeconds(Random.Range(minWait, maxWait));
			Instantiate(crates[Random.Range(0, crates.Length)], this.transform.position, Quaternion.identity);
			drop = true;
		}
	}
}
