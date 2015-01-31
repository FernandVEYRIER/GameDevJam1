using UnityEngine;
using System.Collections;

public class HealthCrateBehaviour : MonoBehaviour {

	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.collider.tag == "Player")
		{
			//add health
			Destroy(this.gameObject);
		}
		if (col.collider.tag == "Ground")
		{
			this.rigidbody2D.isKinematic = true;
			this.collider2D.isTrigger  = true;
			Destroy(this.transform.GetChild(0).gameObject);
		}
	}

	void OnTriggerEnter2D(Collider2D col)
	{

	}
}
