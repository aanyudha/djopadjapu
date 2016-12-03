using UnityEngine;
using System.Collections;

public class scrollMM : MonoBehaviour {

	public float speed = 0;
	Renderer rend;	

	void Start(){
		rend = GetComponent<Renderer>();
	}

	// Update is called once per frame
	void Update () {
		rend.material.mainTextureOffset = new Vector2 (Time.time * speed, 0f);
	}
}
