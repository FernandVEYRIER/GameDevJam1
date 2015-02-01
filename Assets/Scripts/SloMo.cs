using UnityEngine;
using System.Collections;

public class SloMo : MonoBehaviour {

	public AudioClip []sloMoSound;
	public AudioClip[] countSound;
	int count = 0;
	//Percentage of the time scale
	public float percentageSlow = 1f;
	//How many enemies to kill to trigger event
	public float enemyCountTrigger = 3;
	//Min time elapsed between kills
	public float minElapsedTime = 1f;
	public static bool isSloMo = false;

	GameObject[] ennemiesInstancesReference;

	void Start () 
	{
		ennemiesInstancesReference = GameObject.FindGameObjectsWithTag("Enemy");
		audio.PlayOneShot(sloMoSound[0], 20f);
		StartCoroutine(startSloMo());
		isSloMo = true;
	}

	public void playSound()
	{
		audio.PlayOneShot(countSound[count++]);
		if (count >= 3)
		{
			StopAllCoroutines();
			StartCoroutine(stopSloMo());
		}
	}

	IEnumerator startSloMo()
	{
		while (Time.timeScale > percentageSlow)
		{
			Time.timeScale -= 0.01f;
			yield return new WaitForSeconds(0.01f);
		}
	}

	IEnumerator stopSloMo()
	{
		audio.PlayOneShot(sloMoSound[1], 2F);
		while (Time.timeScale < 1)
		{
			Time.timeScale += 0.01f;
			yield return new WaitForSeconds(0.01f);
		}
		Time.timeScale = 1;
		Destroy(this.gameObject, 3f);
		GameManager.score += 1000;
		isSloMo = false;
	}
}
