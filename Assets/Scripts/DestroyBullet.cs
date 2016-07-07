using UnityEngine;
using System.Collections;

public class DestroyBullet : MonoBehaviour {

	public GameObject bloodSplash;
	public GameObject helmetFall;

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.collider2D.tag == "Player")
		{
			col.collider2D.GetComponent<LifeAndAmmo>().lifePoints -= 3;
		}
		else if (col.collider2D.tag == "Enemy")
		{
			GameManager.score += 100;
			if (col.collider2D.name == "Nazi(Clone)")
			{
				Destroy(Instantiate(bloodSplash, this.transform.position, Quaternion.identity), .5f);
				Destroy(Instantiate(helmetFall, this.transform.position, Quaternion.identity), 1f);
			}
			if (SloMo.isSloMo == true)
				GameObject.Find("Clock(Clone)").GetComponent<SloMo>().playSound();
			Destroy(col.gameObject);
		}
		Destroy(this.gameObject);
	}
}
