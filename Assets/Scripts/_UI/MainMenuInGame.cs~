using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuInGame : MonoBehaviour 
{
	void Start()
	{
		Time.timeScale = 1;
		LoadIntro();
	}

	public void LoadIntro()
	{
		Invoke("ShowIntro", 30F);
	}

	void ShowIntro()
	{
		CancelInvoke("ShowIntro");
		SceneManager.LoadScene("Intro", LoadSceneMode.Single);
	}

	public void StartGame()
	{
		CancelInvoke("ShowIntro");
		//SceneManager.LoadScene("Level00", LoadSceneMode.Single);
		SceneManager.LoadScene("LoadSceneScreen", LoadSceneMode.Single);
	}

	public void ShowInstructions()
	{
		CancelInvoke("ShowIntro");
		SceneManager.LoadScene("Instructions", LoadSceneMode.Single);
	}

	public void ShowCredits()
	{
		CancelInvoke("ShowIntro");
		SceneManager.LoadScene("Credits", LoadSceneMode.Single);
	}

	public void ExitGame()
	{
		CancelInvoke("ShowIntro");
		Application.Quit();
	}

	public void GoToMainMenu()
	{
		SceneManager.LoadScene("_Main_Menu", LoadSceneMode.Single);
	}
}
