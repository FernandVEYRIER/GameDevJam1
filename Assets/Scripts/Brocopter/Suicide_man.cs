using UnityEngine;
using System.Collections;

public class Suicide_man : MonoBehaviour {

	public AudioClip	death_sound;
	public GameObject	death_event;
	public float		damage = 30;

	void OnTriggerEnter2D(Collider2D coll) 
	{
		if (coll.collider2D.tag != "Enemy" && coll.collider2D.tag != "Helibros")
		{
			audio.clip = death_sound;
			GameObject death = (GameObject)Instantiate (death_event, transform.position, transform.rotation);
			Destroy (death, audio.clip.length);
			Destroy (gameObject);
		}
		Collider2D[] cols = Physics2D.OverlapCircleAll(this.transform.position, 2);
		foreach (Collider2D col in cols)
		{
			if (col.collider2D.tag == "Player")
			{
				col.collider2D.GetComponent<LifeAndAmmo>().lifePoints -= 30;
			}
		}
	}
}
