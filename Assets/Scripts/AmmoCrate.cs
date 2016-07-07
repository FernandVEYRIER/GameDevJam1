using UnityEngine;
using System.Collections;

public class AmmoCrate : MonoBehaviour {

	#region Rocket Launcher
	[System.Serializable]
	public class persoStats
	{
		public GameObject bullet;
		Transform startPosition;
		public float bulletVelocity = 10f;
		public float bulletDelay = 1;
		public float ammoMagazine = 0.5f;
		public float reloadDelay = 0.5f;
		public AudioClip shootSound;
	}

	#endregion

	public persoStats[] pStats;
	public RuntimeAnimatorController[] anim;
	//public Sprite[] sprite;
	public float 						persistence = 10f;
	public float rocketTime = 10f;

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.GetComponent<Collider2D>().tag == "Player")
		{
			int rand = Random.Range(0, 2);
			if (rand == 0)
				setParamsRocket(col.gameObject);
			else
				setParamsFlameThrower (col.gameObject);

			//reset player stats
			GameObject.Find ("Vestiaire").GetComponent<Vestiaire>().prepareChange(rocketTime);
			Destroy(this.gameObject);
		}
		if (col.GetComponent<Collider2D>().tag == "Ground")
		{
			this.GetComponent<Rigidbody2D>().isKinematic = true;
			this.GetComponent<Collider2D>().isTrigger  = true;
			Destroy(GameObject.Find("Parachute_0"));
			Destroy(this.gameObject, persistence);
		}
	}


	void setParamsRocket(GameObject player)
	{
		player.GetComponent<Collider2D>().GetComponent<Animator>().runtimeAnimatorController = anim[0];
		//player.collider2D.GetComponent<SpriteRenderer>().sprite = sprite[0];
		player.GetComponent<Shoot>().bullet = pStats[0].bullet;
		player.GetComponent<Shoot>().startPos = player.transform.FindChild("spawnRocket").transform;
		player.GetComponent<Shoot>().bulletVelocity = pStats[0].bulletVelocity;
		player.GetComponent<Shoot>().bulletDelay = pStats[0].bulletDelay;
		player.GetComponent<Shoot>().ammoMagazine = pStats[0].ammoMagazine;
		player.GetComponent<Shoot>().reloadDelay = pStats[0].reloadDelay;
		player.GetComponent<Shoot>().shootSound = pStats[0].shootSound;
		player.GetComponent<Shoot>().isFlameThrower = false;
	}

	void setParamsFlameThrower(GameObject player)
	{
		player.GetComponent<Collider2D>().GetComponent<Animator>().runtimeAnimatorController = anim[1];
		//player.collider2D.GetComponent<SpriteRenderer>().sprite = sprite[0];
		player.GetComponent<Shoot>().bullet = pStats[0].bullet;
		player.GetComponent<Shoot>().startPos = player.transform.FindChild("spawnRocket").transform;
		player.GetComponent<Shoot>().bulletVelocity = pStats[0].bulletVelocity;
		player.GetComponent<Shoot>().bulletDelay = pStats[0].bulletDelay;
		player.GetComponent<Shoot>().ammoMagazine = pStats[0].ammoMagazine;
		player.GetComponent<Shoot>().reloadDelay = pStats[0].reloadDelay;
		player.GetComponent<Shoot>().shootSound = pStats[0].shootSound;
		player.GetComponent<Shoot>().isFlameThrower = true;
	}
}
