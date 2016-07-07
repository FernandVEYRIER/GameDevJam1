using UnityEngine;
using System.Collections;

public class Spawn_copter : MonoBehaviour {

	public GameObject	copter;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (GameObject.Find ("Copter(Clone)") == true) 
		{
			return;
		}
		else 
		{
			Instantiate (copter, transform.position, transform.rotation);
		}
	}
}
