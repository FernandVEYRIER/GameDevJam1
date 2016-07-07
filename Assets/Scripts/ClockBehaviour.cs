using UnityEngine;
using System.Collections;

public class ClockBehaviour : MonoBehaviour {


	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.GetComponent<Collider2D>().tag == "Player")
		{
			this.GetComponent<SloMo>().enabled = true;
			this.GetComponent<Collider2D>().enabled = false;
		}
		else if (col.GetComponent<Collider2D>().tag == "Ground")
		{
			this.GetComponent<Collider2D>().isTrigger = true;
			this.GetComponent<Rigidbody2D>().isKinematic = true;
		}
	}
}
