using UnityEngine;
using System.Collections;

public class gotoGameplay : MonoBehaviour {

	// Use this for initialization
	//void Start () {
	
	//}
	
	// Update is called once per frame
	//void Update () {
	
	//}

	public void startGameplay(){
		StartCoroutine (Load2 ()); 

	}

	public void Load()
	{
		StartCoroutine (Load2 ());
	}

	IEnumerator Load2()
	{
		Handheld.SetActivityIndicatorStyle (AndroidActivityIndicatorStyle.Small);

		Handheld.StartActivityIndicator ();
		yield return new WaitForSeconds (0);
		Application.LoadLevel("gameplay");
	}
}
