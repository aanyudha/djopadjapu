﻿using UnityEngine;
using System.Collections;

public class duriMove : MonoBehaviour {
	public GameObject target;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 temp = transform.position;
		temp.x = target.transform.position.x;
		transform.position = temp;

	}
}
