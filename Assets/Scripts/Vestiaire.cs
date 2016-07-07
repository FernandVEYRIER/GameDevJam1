using UnityEngine;
using System.Collections;

public class Vestiaire : MonoBehaviour {

	public GameObject bullet;
	Transform startPosition;
	public float bulletVelocity = 10f;
	public float bulletDelay = 1;
	public float ammoMagazine = 0.5f;
	public float reloadDelay = 0.5f;
	public AudioClip shootSound;
	public RuntimeAnimatorController animController;

	GameObject player;

	public void prepareChange(float delay)
	{
		Invoke("resetPlayerStats", delay);
	}

	void Update()
	{
		player = GameObject.FindGameObjectWithTag("Player");
	}

	public void resetPlayerStats()
	{
		if (player == null)
			return;
		player.GetComponent<Shoot>().bullet = bullet;
		player.GetComponent<Shoot>().startPos = player.transform.FindChild("spawnRocket").transform;
		player.GetComponent<Shoot>().bulletVelocity = bulletVelocity;
		player.GetComponent<Shoot>().bulletDelay = bulletDelay;
		player.GetComponent<Shoot>().ammoMagazine = ammoMagazine;
		player.GetComponent<Shoot>().reloadDelay = reloadDelay;
		player.GetComponent<Shoot>().shootSound = shootSound;
		player.GetComponent<Animator>().runtimeAnimatorController = animController;
		//reset flamethrower
		player.GetComponent<Shoot>().isFlameThrower = false;

	}
}
