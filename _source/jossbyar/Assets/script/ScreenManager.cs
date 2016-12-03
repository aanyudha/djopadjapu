
using UnityEngine;
using System.Collections;



public class ScreenManager : MonoBehaviour {
	
	

	[SerializeField]
	private FadeSprite m_blackScreenCover;
	[SerializeField]
	private float m_minDuration = 4f;
	
	

	//void Update()
	//{
	//	if (Input.GetMouseButtonDown(0))
	//	{
	//		StartCoroutine(LoadSceneAsync("GameScreen"));
	//	}
	//}
	public void StartGame(){
		StartCoroutine(LoadSceneAsync("gameplay"));
		//yield return Application.LoadLevelAdditiveAsync("gameplay");
	}

	public IEnumerator LoadSceneAsync(string sceneName)
	{
		// Fade to black
		yield return StartCoroutine(m_blackScreenCover.FadeIn());
		
		// Load loading screen
		yield return Application.LoadLevelAsync("LoadingScreen");
		
		// !!! unload old screen (automatic)
		
		// Fade to loading screen
		yield return StartCoroutine(m_blackScreenCover.FadeOut());
		
		//memberi waktu di tutorial
		//float endTime = Time.time + m_minDuration;
		
		// Load level async (load gameplay)
		//yield return Application.LoadLevelAdditiveAsync(sceneName);
		
		//memberi waktu di tutorial
		//while (Time.time < endTime)
		//	yield return null;
		
		// Fade to black
		//yield return StartCoroutine(m_blackScreenCover.FadeIn());
		
		// !!! unload loading screen
		//LoadingSceneManager.UnloadLoadingScene();
		
		// Fade to new screen
		yield return StartCoroutine(m_blackScreenCover.FadeOutFast());
	}


}
