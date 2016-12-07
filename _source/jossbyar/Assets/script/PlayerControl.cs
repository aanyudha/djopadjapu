using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerControl : MonoBehaviour {

	public bool alreadyCollide = false;
	public bool isJapu = true;
	public float resultDistance = 0;
	private float delay = 0.0F;
	public float addDelay = 0.2F;
	Animator animator;

	public float distance = 0.0f;
	private float distanceAddFrame;
	private float ADD_METER_EVERY = 20.0f;
	private float initial_y = 0.0f;
	private float delayBeforeRetry = 0.0f;

	private Vector3 fp;   //First touch position
	public bool visibleMenu = false;
	bool isCollide = false;
	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
		initial_y = transform.position.y;
	}

	// Update is called once per frame
	void update(){
		
	}
	

	void FixedUpdate () {

		//Debug.Log ("akuaku  "+delayBeforeRetry);
		if (delayBeforeRetry > 0) {
			delayBeforeRetry--;
			//Debug.Log ("lewattttttttttttttttt  "+delayBeforeRetry);
			if( delayBeforeRetry == 1 )
			{
				delayBeforeRetry = 0.0f;
				var gameOver = FindObjectOfType<GameOver> ();

				if (gameOver != null && gameOver.distance_tyus <= 0) {

					// Game Over.

					gameOver.distance_tyus = distance;
					gameOver.ShowButtons ();
					//gameOver.DisplayDistance ();
				}
			}
		}

		if (Input.GetKey ("mouse 0") && Time.time > delay ) {
			isCollide = false;
			if(isJapu)
			Debug.Log ("tyussss  "+transform.position.y);
			delay = Time.time + addDelay;

			// initial variable
			float japu_y_bottom = -3.8f;
			float japu_y_top = -0.8f;
			float jopa_y_top = 4.25f;
			float jopa_y_bottom = 1.3f;
			float y_range = 0.1f;

			//;

			if (Input.mousePosition.y > Screen.height/2) {//pencet atas
				print ("mencet atas  "+Screen.height+"  "+Input.mousePosition.y);
				if (isJapu) {					
					if (transform.position.y < initial_y + y_range && transform.position.y > initial_y - y_range)//dr tengah ke bawah
						transform.position = (new Vector3 (transform.position.x, japu_y_bottom, 0));
					else if (transform.position.y < japu_y_top + y_range && (transform.position.y > japu_y_top - y_range)) // dr atas ke tengah
						transform.position = (new Vector3 (transform.position.x, initial_y, 0));
				} else { // jopa
					if (transform.position.y > initial_y - y_range && transform.position.y < initial_y + y_range)//dr tengah ke atas
						transform.position = (new Vector3 (transform.position.x, jopa_y_top, 0));
					else if (transform.position.y > jopa_y_bottom - y_range && (transform.position.y < jopa_y_bottom + y_range))// dr bawah ke tengah
						transform.position = (new Vector3 (transform.position.x, initial_y, 0));
				}
			} else { // pencet bawah
				print("mencet bawah  "+Screen.height+"  "+Input.mousePosition.y);
				if (isJapu) {					
					if (transform.position.y < initial_y + y_range && transform.position.y > initial_y - y_range)//dr tengah ke atas
						transform.position = (new Vector3 (transform.position.x, japu_y_top, 0));
					else if (transform.position.y < japu_y_bottom + y_range && (transform.position.y > japu_y_bottom - y_range)) // dr bawah ke tengah
						transform.position = (new Vector3 (transform.position.x, initial_y, 0));
				} else { // jopa
					if (transform.position.y > initial_y - y_range && transform.position.y < initial_y + y_range)//dr tengah ke atas
						transform.position = (new Vector3 (transform.position.x, jopa_y_bottom, 0));
					else if (transform.position.y > jopa_y_top - y_range && (transform.position.y < jopa_y_top + y_range)) // dr atas ke tengah
						transform.position = (new Vector3 (transform.position.x, initial_y, 0));
				}
			}
		}

		if (!isCollide) {
			transform.Translate(new Vector3(0.034f,0,0));
			if (distanceAddFrame > 0) {
				distanceAddFrame--;
			}
			else {	
				if (!alreadyCollide) {
					distance += 1;
					distanceAddFrame = ADD_METER_EVERY;
				}
			}

		}

		
		//if(top.Contains(Input.GetTouch.position))
		//{
			//Debug.Log("TOP");
		//}
		//else
		//{
		//	//Debug.Log("Bottom");
		//}
		//foreach (Touch touch in Input.touches) {  //use loop to detect more than one swipe//can be ommitted if you are using lists 
			// if (touch.phase == TouchPhase.Began) //check for the first touch
			// {
				// fp = Input.Touch.position;		        
		 
			// }			
			
			// if ((fp.y < 360)) {  //If the movement was to the right)//Right swipe
				// Debug.Log ("Right Swipe");
				// if(isJapu)
					// transform.Translate (new Vector3 (0, -0.5f, 0));
				// else
					// transform.Translate (new Vector3 (0, 0.5f, 0));
				
			// } else {   //Left swipe
				// Debug.Log ("Left Swipe"); 
				// if(isJapu)
					// transform.Translate (new Vector3 (0, 0.5f, 0));
				// else
					// transform.Translate (new Vector3 (0, -0.5f, 0));
			// }	

	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		resultDistance = distance;
		// Collision with enemy
		Obstacle obstacle = collision.gameObject.GetComponent<Obstacle>();
		//alreadyCollide = true;
		visibleMenu = true;

		//GetComponent<AudioSource>().Play();

		//GetComponent<AudioSource>().Play();
		if (obstacle != null) {
			isCollide = true;



			if (!isJapu) {
				animator.SetBool ("japu_dead", true);

				if(!alreadyCollide)
				GetComponent<AudioSource>().Play();
				alreadyCollide = true;
			} else {
				animator.SetBool ("jopa_dead", true);

				if(!alreadyCollide)
				GetComponent<AudioSource>().Play();
				alreadyCollide = true;
			}

			//var stopCam = FindObjectOfType<cameraMove>();
			//stopCam.stopingCamera ();
			delayBeforeRetry = 50.0f;
			Debug.Log ("lewat sini kok  "+delayBeforeRetry);




			}
		}



	void DisplayDistance()
	{
		if (!isJapu)
			return;
		Rect coinIconRect = new Rect(8, 13, 32, 32);
		//GUI.DrawTexture(coinIconRect, coinIconTexture);                         
		 //style1.font = 
		GUIStyle style = new GUIStyle();
		style.font = (Font)Resources.Load("snake");
		style.fontSize = 15;
		//style.fontStyle = FontStyle.Bold;
		style.normal.textColor = Color.white;

		Rect labelRect = new Rect(15, coinIconRect.y, 60, 32);
		GUI.Label(labelRect, "DISTANCE : " + distance.ToString(), style);
	}
		
	void OnGUI()
	{
		if(!alreadyCollide)
		DisplayDistance ();
	}
}


