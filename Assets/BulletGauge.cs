using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BulletGauge : MonoBehaviour {

	Image bulletGauge;
	float fillAmmount = 1;
	float percentage;
	GameObject player;

	void Start () 
	{
		player = GameObject.FindGameObjectWithTag("Player");
		bulletGauge = this.GetComponent<Image>();
		percentage = player.GetComponent<Shoot>().ammoMagazine;
	}


	void Update () 
	{
		bulletGauge.fillAmount = player.GetComponent<Shoot>().currentAmmo / percentage;
	}
}
