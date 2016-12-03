using UnityEngine;
using System.Collections;

public class Obstacle : MonoBehaviour {
	private Collider2D coliderComponent;
	Animator animator;
	// Use this for initialization
	void Start () {
		coliderComponent = GetComponent<Collider2D>();
		coliderComponent.enabled = true;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		//if(collision.gameObject.CompareTag("Player"))
		//Debug.Log("haiyaahhhhh");
		//animator.SetBool ("collide", true);
	}
}
