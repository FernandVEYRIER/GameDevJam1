using UnityEngine;
using System.Collections;

public class MissileLargeCollision : MonoBehaviour {

	public GameObject bigExplosionPrefab;
	public AudioClip explosionSound;
	
	void OnTriggerEnter2D(Collider2D colli)
	{
		Collider2D[] cols = Physics2D.OverlapCircleAll(this.transform.position, 2);
		foreach (Collider2D col in cols)
		{
			Debug.Log(col.collider2D.name);
			if (col.collider2D.tag == "Player")
			{
				col.collider2D.GetComponent<LifeAndAmmo>().lifePoints -= 10;
			}
		}
		audio.PlayOneShot(explosionSound);
		Destroy(Instantiate(bigExplosionPrefab, this.transform.position + Vector3.right, Quaternion.identity), 2f);
		Destroy(this.gameObject);
	}
}
