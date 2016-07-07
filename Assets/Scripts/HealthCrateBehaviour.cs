using UnityEngine;
using System.Collections;

public class HealthCrateBehaviour : MonoBehaviour {

	public int lifeGiven = 10;
	public float persistence = 10f;

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.GetComponent<Collider2D>().tag == "Player")
		{
			col.GetComponent<Collider2D>().GetComponent<LifeAndAmmo>().lifePoints += lifeGiven;
			Destroy(this.gameObject);
		}
		if (col.GetComponent<Collider2D>().tag == "Ground")
		{
			this.GetComponent<Rigidbody2D>().isKinematic = true;
			this.GetComponent<Collider2D>().isTrigger  = true;
			Destroy(GameObject.Find("Parachute_0"));
			Destroy(this.gameObject, persistence);
		}
	}
}
