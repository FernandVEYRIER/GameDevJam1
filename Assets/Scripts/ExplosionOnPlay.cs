using UnityEngine;
using System.Collections;

public class ExplosionOnPlay : MonoBehaviour {
	
	public GameObject explosionPrefab;
	public AudioClip explosionSound;

	void Start()
	{
		StartCoroutine("explosions");
		Destroy(this.gameObject, 2.7f);
	}

	IEnumerator explosions()
	{
		for (int i = 0; i < 80; i++)
		{
			GameObject go = (GameObject) Instantiate(explosionPrefab, Random.insideUnitCircle, Quaternion.identity);
			audio.PlayOneShot(explosionSound, 0.1f);
			Destroy(go, 2f);
			go.transform.SetParent(this.transform);
			yield return new WaitForSeconds(0.01f);
		}
		Destroy(GameObject.Find("Explosion(Clone)"));
	}

	public void OnQuitButton()
	{
		Application.Quit();
	}
}
