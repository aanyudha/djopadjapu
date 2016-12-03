using UnityEngine;
using System.Collections;

public class BGfollow : MonoBehaviour {

	public GameObject target; 
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 newPosition = transform.position;
		newPosition.x = target.transform.position.x;
		transform.position = newPosition;
	}
}
