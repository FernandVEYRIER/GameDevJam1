using UnityEngine;
using System.Collections;

public class Suicide_man : MonoBehaviour {

	public AudioClip	death_sound;
	public GameObject	death_event;
	public float		damage = 30;

	void OnTriggerEnter2D(Collider2D coll) 
	{
		if (coll.GetComponent<Collider2D>().tag != "Enemy" && coll.GetComponent<Collider2D>().tag != "Helibros")
		{
			GetComponent<AudioSource>().clip = death_sound;
			GameObject death = (GameObject)Instantiate (death_event, transform.position, transform.rotation);
			Destroy (death, GetComponent<AudioSource>().clip.length);
			Destroy (gameObject);
		}
		Collider2D[] cols = Physics2D.OverlapCircleAll(this.transform.position, 2);
		foreach (Collider2D col in cols)
		{
			if (col.GetComponent<Collider2D>().tag == "Player")
			{
				col.GetComponent<Collider2D>().GetComponent<LifeAndAmmo>().lifePoints -= 30;
			}
		}
	}
}
