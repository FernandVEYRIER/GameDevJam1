using UnityEngine;
using System.Collections;

public class AudioManager : MonoBehaviour {

	public AudioClip[] audioClips;

	void Start () 
	{
		audio.PlayOneShot(audioClips[0]);
	}
	
	void Update () 
	{
	
	}
}
