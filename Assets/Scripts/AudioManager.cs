using UnityEngine;
using System.Collections;

public class AudioManager : MonoBehaviour {

	public AudioClip[] audioClips;

	void Start () 
	{
		GetComponent<AudioSource>().PlayOneShot(audioClips[0], 3f);
	}
	
	void Update () 
	{
	
	}
}
