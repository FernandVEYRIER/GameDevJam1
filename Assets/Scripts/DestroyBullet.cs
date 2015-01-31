using UnityEngine;
using System.Collections;

public class DestroyBullet : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.collider2D.tag == "Player")
		{
			col.collider2D.GetComponent<LifeAndAmmo>().lifePoints--;
		}
		else if (col.collider2D.tag == "Enemy")
		{
			GameManager.score += 100;
			Destroy(col.gameObject);
		}
		Destroy(this.gameObject);
	}
}
