using UnityEngine;
using System.Collections;

public class MissileLargeCollision : MonoBehaviour {

	public GameObject 	bigExplosionPrefab;
	public AudioClip 	explosionSound;
	public int			damage = 20;

	void OnTriggerEnter2D(Collider2D colli)
	{
		Collider2D[] cols = Physics2D.OverlapCircleAll(this.transform.position, 1.5f);
		foreach (Collider2D col in cols)
		{
			if (col.GetComponent<Collider2D>().tag == "Player")
			{
				col.GetComponent<Collider2D>().GetComponent<LifeAndAmmo>().lifePoints -= damage;
			}
		}
		GetComponent<AudioSource>().PlayOneShot(explosionSound);
		Destroy(Instantiate(bigExplosionPrefab, this.transform.position + Vector3.right, Quaternion.identity), 2f);
		Destroy(this.gameObject);
	}
}
