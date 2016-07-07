using UnityEngine;
using System.Collections;

public class DeadTrigger : MonoBehaviour {
	

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.GetComponent<Collider2D>().tag == "Player")
		{
			col.GetComponent<Collider2D>().GetComponent<LifeAndAmmo>().lifePoints = 0;
		}
		else
		{
			Destroy(col.gameObject);
		}
	}
}
