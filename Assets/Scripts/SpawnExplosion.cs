using UnityEngine;
using System.Collections;

public class SpawnExplosion : MonoBehaviour {

	public GameObject explosionPrefab;
	public float radius = 3f;

	//Grenade explosion
	void OnDestroy()
	{
		//add sphere cast to destroy ennemies, and increase score
		GameObject go = (GameObject) Instantiate(explosionPrefab, this.transform.position, Quaternion.identity);
		Collider2D[] allCol = Physics2D.OverlapCircleAll(this.transform.position, radius);
		foreach (Collider2D col in allCol)
		{
			if (col.collider2D.tag == "Enemy")
			{
				GameManager.score += 100;
				Destroy(col.collider2D.gameObject);
			}
		}
		Destroy(go, 1f);
	}
}
