using UnityEngine;
using System.Collections;

public class cameraFollowChar : MonoBehaviour {

	public GameObject target;
	//public GameObject target2;
	private float distanceToTarget;

	// Use this for initialization
	void Start () {
		distanceToTarget = transform.position.x - target.transform.position.x;
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 newCameraPosition = transform.position;
		newCameraPosition.x = target.transform.position.x + distanceToTarget;
		transform.position = newCameraPosition;
	}
}
