using UnityEngine;
using System.Collections;

public class SloMo : MonoBehaviour {

	public AudioClip sloMoSound;
	public AudioClip[] countSound;
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
		audio.PlayOneShot(sloMoSound, 50f);
		StartCoroutine(startSloMo());
		isSloMo = true;
	}

	public void playSound()
	{
		audio.PlayOneShot(countSound[0]);
	}

	IEnumerator startSloMo()
	{
		while (Time.timeScale > percentageSlow)
		{
			Time.timeScale -= 0.01f;
			yield return new WaitForSeconds(0.01f);
		}
	}
}
