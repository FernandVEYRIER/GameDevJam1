using UnityEngine;
using System.Collections;

public class DestroyRocket : MonoBehaviour {

	public GameObject 	bloodSplash;
	public GameObject 	bigExplosionPrefab;
	public AudioClip 	explosionSound;

	void OnTriggerEnter2D(Collider2D colli)
	{
		Collider2D[] cols = Physics2D.OverlapCircleAll(this.transform.position, 2);
		foreach (Collider2D col in cols)
		{
			if (col.collider2D.tag == "Enemy")
			{
				GameManager.score += 100;
				if (col.collider2D.name == "Nazi(Clone)")
					Destroy(Instantiate(bloodSplash, this.transform.position, Quaternion.identity), .5f);
				if (SloMo.isSloMo == true)
					GameObject.Find("Clock(Clone)").GetComponent<SloMo>().playSound();
				Destroy(col.gameObject);
			}
		}
		audio.PlayOneShot(explosionSound);
		Destroy(Instantiate(bigExplosionPrefab, this.transform.position + Vector3.right, Quaternion.identity), 2f);
		Destroy(this.gameObject);
	}
}
