using UnityEngine;
using System.Collections;

public class ExplosionOnPlay : MonoBehaviour {
	
	public GameObject explosionPrefab;
	public AudioClip explosionSound;

	public void OnPlayButton()
	{
		StartCoroutine("explosions");
		Destroy(this.gameObject, 2.4f);
	}

	IEnumerator explosions()
	{
		for (int i = 0; i < 80; i++)
		{
			GameObject go = (GameObject) Instantiate(explosionPrefab, Random.insideUnitCircle, Quaternion.identity);
			audio.PlayOneShot(explosionSound);
			go.transform.SetParent(this.transform);
			yield return new WaitForSeconds(0.01f);
		}
	}

	public void OnQuitButton()
	{
		Application.Quit();
	}
}
