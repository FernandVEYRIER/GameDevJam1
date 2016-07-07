using UnityEngine;
using System.Collections;

public class Event_manager : MonoBehaviour {

	[System.Serializable]
	public class Value
	{	
		public GameObject 	event_obj;
		public bool			enable = true;
		public float		delay;
	}
	public Value[]		events;
	// Use this for initialization
	void Start ()
	{
		foreach (Value val in events)
		{
			StartCoroutine(event_time(val.delay, val.event_obj));	
		}
	}
	IEnumerator event_time (float time, GameObject eve)
	{
		while (42 == 42)
		{
			eve.SetActive (false);
			yield return new WaitForSeconds (time);
			eve.SetActive (true);
		}
    }
}
