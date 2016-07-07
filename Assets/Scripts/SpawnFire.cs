using UnityEngine;
using System.Collections;

public class SpawnFire : MonoBehaviour {

	ParticleEmitter childEmitter;
	Transform playerTransform;
	public AudioClip flameSound;
	bool isNotPlaying = true;

	void Start () 
	{
		childEmitter = this.transform.FindChild("Smoke").GetComponent<ParticleEmitter>();
		playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
	}
	
	void Update () 
	{
		if (playerTransform.transform.GetComponent<Shoot>().isFlameThrower == true)
		{
			if (isNotPlaying == true && Input.GetButton("Fire1") )
			{
				isNotPlaying = false;
				StartCoroutine(playSound());
			}
			else if (Input.GetButtonUp("Fire1"))
			{
				StopAllCoroutines();
				isNotPlaying = true;
			}
			this.particleEmitter.localVelocity = new Vector3 (-playerTransform.localScale.x * 3, 0, 0);
			childEmitter.localVelocity = new Vector3 (-playerTransform.localScale.x * 3, 0, 0);
			this.particleEmitter.emit = Input.GetButton("Fire1");
			childEmitter.emit = Input.GetButton("Fire1");
			this.GetComponent<Collider2D>().enabled = Input.GetButton("Fire1");
		}
		else
		{
			StopAllCoroutines();
			isNotPlaying = true;
			childEmitter.emit = false;
			this.particleEmitter.emit = false;
			this.GetComponent<Collider2D>().enabled = false;
		}
	}

	IEnumerator playSound()
	{
		while (true)
		{
			audio.Play();
			yield return new WaitForSeconds(flameSound.length);
		}
	}
}
