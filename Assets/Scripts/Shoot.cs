using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour {

	public GameObject bullet;
	public Transform startPos;
	public float bulletVelocity = 100F;
	public float bulletDelay = .2f;
	private float lastShot = -1;

	//Delay he can toggle fire before reloading
	public float ammoMagazine = 4f;
	float currentAmmo;
	public float reloadDelay = 1f;
	public AudioClip reloadSound;

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
		if (lastShot < 0 && currentAmmo > 0 && Input.GetButton("Fire1"))
		{
			currentAmmo -= Time.deltaTime;
			lastShot = bulletDelay;
			GameObject go = (GameObject) Instantiate(bullet, startPos.position, Quaternion.identity);
			go.rigidbody2D.velocity = new Vector2(bulletVelocity * -playerScale.localScale.x, 0);
			audio.PlayOneShot(shootSound, 0.5f);
			Destroy(go, 2f);
		}
		if (currentAmmo <= 0 && lastShot < 0)
		{
			//disable shot while reloading
			lastShot = 999;
			audio.PlayOneShot(reloadSound);
			Invoke("reloadWeapon", reloadDelay);
		}
	}

	void reloadWeapon()
	{
		lastShot = -1;
		currentAmmo = ammoMagazine;
	}
}
