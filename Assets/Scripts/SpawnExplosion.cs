using UnityEngine;
using System.Collections;

public class SpawnExplosion : MonoBehaviour {

	public GameObject explosionPrefab;
	public AudioClip explosionSound;
	
	void OnDestroy()
	{
		//add sphere cast to destroy ennemies, and increase score
		GameObject go = (GameObject) Instantiate(explosionPrefab, this.transform.position, Quaternion.identity);
		audio.PlayOneShot(explosionSound);
		Destroy(go, 3f);
	}
}
