using UnityEngine;
using System.Collections;

public class DeadTrigger : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.collider2D.tag == "Player")
		{
			col.collider2D.GetComponent<LifeAndAmmo>().lifePoints = 0;
		}
		else
		{
			Destroy(col.gameObject);
		}
	}
}
