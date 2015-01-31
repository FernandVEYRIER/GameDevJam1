using UnityEngine;
using System.Collections;

public class Suicide_man : MonoBehaviour {

	public AudioClip	death_sound;
	public GameObject	death_event;
	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}
	void OnTriggerEnter2D(Collider2D coll) 
	{
		if (coll.collider2D.tag != "Enemy")
		{
			audio.clip = death_sound;
			GameObject death = (GameObject)Instantiate (death_event, transform.position, transform.rotation);
			Destroy (death, audio.clip.length);
			Destroy (gameObject);
		}
	}
}
