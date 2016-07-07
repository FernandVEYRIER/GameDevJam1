using UnityEngine;
using System.Collections;

public class LifeAndAmmo : MonoBehaviour {

	public int lifePoints = 100;
	public int ammo = 10;
	public string [] WhatIsEnemy = {"Enemy"};

	void OnCollisionEnter2D (Collision2D col)
	{
		foreach(string layerName in WhatIsEnemy)
		{
			if (layerName == col.collider.name)
			{
				lifePoints--;
			}
		}
		if (lifePoints < 20 && GetComponent<AudioSource>().isPlaying == false)
		{
			GetComponent<AudioSource>().Play();
		}
		else if (lifePoints >= 20 && GetComponent<AudioSource>().isPlaying == true)
		{
			GetComponent<AudioSource>().Stop ();
		}
	}
}
