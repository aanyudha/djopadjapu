using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class generateBG : MonoBehaviour {

	public GameObject BG;
	public List<GameObject> currentBG;
	private float screenWidthInPoints;
	private float roomWidth;

	// Use this for initialization
	void Start () {
		float height = 2.0f * Camera.main.orthographicSize;
		screenWidthInPoints = height * Camera.main.aspect;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate()
	{
		generateIfRequired ();
	}

	void AddBG(float fartestBGEndx)
	{
		float roomWidth = BG.transform.FindChild ("bgwidth").localScale.x;
		float roomCenter = fartestBGEndx + roomWidth * 0.5f;
		BG.transform.position = new Vector3 (roomCenter,0,0);
		currentBG.Add (BG);
	}

	void generateIfRequired()
	{
		//Debug.Log ("sinisnsini");
		List<GameObject> BGsToRemove = new List<GameObject>();
		bool addingBG = false;
		float fartestBGEndX = 0;

		foreach (var bege in currentBG) {
			
			roomWidth = bege.transform.FindChild ("bgwidth").localScale.x / 2;
			Debug.Log ("sinis gak "+bege.transform.position.x);
			if (bege.transform.position.x < 0) {
				addingBG = true;
				Debug.Log ("sudah lwat");
			}

			//float halfWidth = roomWidth / 2;
			//float startX = bege.transform.position.x - halfWidth;
			//float BGEndX = startX + roomWidth;

			//Debug.Log ("roomwidth = "+roomWidth+" "+startX+" "+BGEndX);

			//if (bege.transform.position.x < 0)
			//	addingBG = true;

			//if (BGEndX < 0)
			//	BGsToRemove.Add (bege);

			//fartestBGEndX = Mathf.Max (fartestBGEndX, BGEndX);		}

		//foreach (var bge in BGsToRemove) {
			//currentBG.Remove (bge);
			//Destroy (bge);
		}

		if (addingBG)
			AddBG (fartestBGEndX);
	}
}
