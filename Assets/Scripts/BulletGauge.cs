using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BulletGauge : MonoBehaviour {

	Image bulletGauge;
	float percentage;
	GameObject player;
	bool isReloading = false;
	float currentVel;

	void Start () 
	{
		player = GameObject.FindGameObjectWithTag("Player");
		bulletGauge = this.GetComponent<Image>();
		percentage = player.GetComponent<Shoot>().ammoMagazine;
	}


	void Update () 
	{
		if (!isReloading)
		{
			bulletGauge.fillAmount = player.GetComponent<Shoot>().currentAmmo / percentage;
		}
		if (isReloading)
		{
			bulletGauge.fillAmount = Mathf.SmoothDamp(bulletGauge.fillAmount, player.GetComponent<Shoot>().currentAmmo / percentage, ref currentVel, 0.3f);
		}
		if (bulletGauge.fillAmount == 0)
		{
			isReloading = true;
			Invoke ("CancelReloadState" , 2f);
		}
		if (bulletGauge.fillAmount >= 0.90)
			isReloading = false;
	}

	void CancelReloadState()
	{
		isReloading = false;
	}
}
