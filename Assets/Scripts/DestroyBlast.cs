﻿using UnityEngine;
using System.Collections;

public class DestroyBlast : MonoBehaviour {

	// Use this for initialization
	void Start () 
	{
		Destroy(this.gameObject, 0.5f);
	}

}
