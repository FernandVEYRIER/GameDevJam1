using UnityEngine;
using System.Collections;

public class FlameThrower : MonoBehaviour {

	public GameObject particleFire;

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.collider2D.name == "Nazi(Clone)")
		{
			GameObject go = (GameObject) Instantiate(particleFire, col.transform.position + new Vector3(0, 0, -1), Quaternion.identity);
			go.transform.SetParent(col.transform);
			col.GetComponent<NaziAI>().isOnFire = true;
			GameManager.score += 10;
		}
	}
}
