﻿using UnityEngine;
using System.Collections;

public class MMmoveBG : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (new Vector3(-0.03f,0,0));
	}
}
