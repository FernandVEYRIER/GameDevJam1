using UnityEngine;
using System.Collections;

public class ClockBehaviour : MonoBehaviour {


	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.collider2D.tag == "Player")
		{
			this.GetComponent<SloMo>().enabled = true;
			this.collider2D.enabled = false;
		}
		else if (col.collider2D.tag == "Ground")
		{
			this.collider2D.isTrigger = true;
			this.rigidbody2D.isKinematic = true;
		}
	}
}
