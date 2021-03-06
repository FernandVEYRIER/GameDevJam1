﻿using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour {
	
	public GameObject bullet;
	public Transform startPos;
	public float bulletVelocity = 100F;
	public float bulletDelay = .2f;
	private float lastShot = -1;

	//Delay he can toggle fire before reloading
	public float ammoMagazine = 4f;
	[HideInInspector]
	public float currentAmmo;
	public float reloadDelay = 1f;
	public AudioClip [] reloadSound;
	public AudioClip clipReload;

	[HideInInspector]
	public bool isFlameThrower = false;
	public AudioClip shootSound;
	Transform playerScale;

	//Player shooting
	void Start()
	{
		currentAmmo = ammoMagazine;
		playerScale = this.transform.GetComponentInParent<Transform>();
	}

	void Update () 
	{
		lastShot -= Time.deltaTime;
		if (!isFlameThrower)
		{
			if (lastShot < 0 && currentAmmo > 0 && Input.GetButton("Fire1"))
			{
				currentAmmo -= Time.deltaTime;
				lastShot = bulletDelay;
				GameObject go = (GameObject) Instantiate(bullet, startPos.position, Quaternion.identity);
				go.GetComponent<Rigidbody2D>().velocity = new Vector2(bulletVelocity * -playerScale.localScale.x, 0);
				go.transform.localScale = new Vector3(-playerScale.transform.localScale.x * go.transform.localScale.x, go.transform.localScale.y, 1);
				GetComponent<AudioSource>().PlayOneShot(shootSound, 0.3f);
				Destroy(go, 2f);
			}
			if (currentAmmo <= 0 && lastShot < 0 || (Input.GetKeyDown(KeyCode.R) && currentAmmo != ammoMagazine && lastShot < 0))
			{
				//disable shot while reloading, and play sounds
				int audioToPlay = Random.Range(0, reloadSound.Length);
				GetComponent<AudioSource>().PlayOneShot( reloadSound[audioToPlay], (audioToPlay == 0) ? 0.3f : 2.5f );
				lastShot = 999;
				Invoke("reloadWeapon", reloadDelay);
			}
		}
	}

	void reloadWeapon()
	{
		GetComponent<AudioSource>().PlayOneShot(clipReload, 3f);
		lastShot = -1;
		currentAmmo = ammoMagazine;
	}
	
}
