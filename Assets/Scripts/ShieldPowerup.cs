using UnityEngine;
using System.Collections;

public class ShieldPowerup : MonoBehaviour {

	public GameObject shieldPrefab;

	void Start () 
	{
		StartCoroutine(rotateShield());	
	}
	
	IEnumerator rotateShield()
	{
		bool increaseX = false;
		float xScale = 1;
		while (true)
		{
			if (!increaseX)
			{
				xScale -= Time.deltaTime;
			}
			else
			{
				xScale += Time.deltaTime;
			}
			this.GetComponent<Transform>().localScale = new Vector3(xScale, 1, 1);
			if (xScale >= 0.99f)
				increaseX = false;
			else if (xScale <= -0.99f)
				increaseX = true;
			yield return new WaitForSeconds(0.01f);
		}
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.GetComponent<Collider2D>().tag == "Player")
		{
			GameObject go = (GameObject) Instantiate(shieldPrefab, col.transform.position, Quaternion.identity);
			go.transform.SetParent(col.transform);
			go.transform.position = new Vector3(go.transform.position.x, go.transform.position.y, go.transform.position.z - 0.1f);
			Destroy(this.gameObject);
		}
		if (col.GetComponent<Collider2D>().tag == "Ground")
		{
			this.GetComponent<Rigidbody2D>().isKinematic = true;
		}
	}
}
