using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Start or quit the game
/// </summary>
public class GameOver : MonoBehaviour
{
	private Button[] buttons;
	private Image[] image;
	float distanceX = -1000.0f;
	public float distance_tyus = 0.0f;
	void Awake()
	{
		// Get the buttons
		buttons = GetComponentsInChildren<Button>();
		//image = GetComponentsInChildren<Image>();

		// Disable them
		HideButtons();
	}

	public void HideButtons()
	{
		foreach (var b in buttons)
		{
			b.gameObject.SetActive(false);
		}

		//foreach (var c in image)
		//{
			//c.gameObject.SetActive(false);
		//}
	}

	public void ShowButtons()
	{
		distanceX = Screen.width/3;

		foreach (var b in buttons)
		{
			b.gameObject.SetActive(true);
		}

		//foreach (var c in image)
		//{
			//c.gameObject.SetActive(true);
		//}
	}

	public void ExitToMenu()
	{
		// Reload the level
		//Debug.Log("Exit");
		//GetComponent<AudioSource>().Play();
		Application.LoadLevel("main_menu");
	}

	public void RestartGame()
	{
		// Reload the level
		//Debug.Log("Restart");
		//GetComponent<AudioSource>().Play();
		Application.LoadLevel("gameplay");
	}

	public void DisplayDistance()
	{		
		var player = FindObjectOfType<PlayerControl>();

		//Rect coinIconRect = new Rect(10, 10, 32, 32);
		//GUI.DrawTexture(coinIconRect, coinIconTexture);                         

		GUIStyle style = new GUIStyle();
	  style.font = (Font)Resources.Load("snake");
	  style.fontSize = 30;
	  //style.fontStyle = FontStyle.Bold;
	  style.normal.textColor = Color.white;

		Rect labelRect = new Rect(distanceX, 200, 60, 100);
		GUI.Label(labelRect, "DISTANCE : " + distance_tyus.ToString(), style);
	}


	// void DisplayDistance()
 // {
  // if (!isJapu)
   // return;
  // Rect coinIconRect = new Rect(10, 13, 32, 32);
  // //GUI.DrawTexture(coinIconRect, coinIconTexture);                         
   // //style1.font = 
  // GUIStyle style = new GUIStyle();
  // style.font = (Font)Resources.Load("snake");
  // style.fontSize = 7;
  // //style.fontStyle = FontStyle.Bold;
  // style.normal.textColor = Color.white;

  // Rect labelRect = new Rect(coinIconRect.xMax, coinIconRect.y, 60, 32);
  // GUI.Label(labelRect, "DISTANCE : " + distance.ToString(), style);
 // }
	
	void OnGUI()
	{
		var player = FindObjectOfType<PlayerControl>();

			DisplayDistance ();
	}
}