using UnityEngine;
using System.Collections;

public class HealthCrateBehaviour : MonoBehaviour {

	public int lifeGiven = 10;
	public float persistence = 10f;

	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.collider.tag == "Player")
		{
			col.collider.GetComponent<LifeAndAmmo>().lifePoints += lifeGiven;
			Destroy(this.gameObject);
		}
		if (col.collider.tag == "Ground")
		{
			this.rigidbody2D.isKinematic = true;
			this.collider2D.isTrigger  = true;
			Destroy(this.transform.GetChild(0).gameObject);
			Destroy(this.gameObject, persistence);
		}
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.collider2D.tag == "Player")
		{
			col.collider2D.GetComponent<LifeAndAmmo>().lifePoints += lifeGiven;
            Destroy(this.gameObject);
		}
	}
}
