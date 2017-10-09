using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
	#region Game Events
	public delegate void GameOverEventHandler (object source, EventArgs args);
	public delegate void PauseGameEventHandler(object source, bool value);
	public delegate void ContinueAfterAdEventHandler(object source, bool value);
	public event GameOverEventHandler GameOvered;
	public event PauseGameEventHandler PausedGame;
	public event ContinueAfterAdEventHandler ContinuedAfterDead;
	#endregion

	public static float itemSpeed { get; private set; }
	internal static bool isGameOver = false;
	internal static bool isPaused = false;
	public float timePlaying { get; private set; }
	public ItemMatrix theMatrix;

	bool gameOverCheck;

	#region Difficul Creator Variables
	private const float  OBS_CONST 		= 1.65F;
	private const float HAZ_CONST 		= 0.1F;
	private const float DIFF_TIME_CONST = 1.5F;
	private const float DIFF_CONST 		= 0.9F;
	private const float CREAT_DELAY 	= 4F;
	public int dificulty 				{get; private set;}
	#endregion

	#region Stats and Records
	public int lifes;
	public static int 	TimeOnWave 		{get; private set;}
	public static int 	PeopleSaved 	{get; private set;}
	public static int 	TimeRecod 		{get; private set;}
	public static int 	PeopleRecord	{get; private set;}
	#endregion

	void Start()
	{
		Time.timeScale = 1;
		isPaused = false;
		
		TimeOnWave = 0;
		PeopleSaved = 0;
		dificulty = 0;

		isGameOver = false;
		gameOverCheck = false;
		lifes = 1;
		timePlaying = 0;
		itemSpeed = 0;
		StartCoroutine(SetDificult());
		TimeRecod 		= PlayerPrefs.GetInt("Time on Wave", 180);
		PeopleRecord 	= PlayerPrefs.GetInt("Innocent Saved", 90);
	}

	void Update()
	{
		//print("lifes " + lifes);

		if(!isGameOver)
		{
			timePlaying += Time.deltaTime;
			itemSpeed += Time.deltaTime/15;
			itemSpeed = Mathf.Clamp(itemSpeed, 0.0F, 10.0F);

			TimeOnWave = Mathf.RoundToInt(timePlaying);

			if(TimeOnWave > TimeRecod)
			{
				PlayerPrefs.SetInt("Time on Wave", TimeOnWave);
				TimeRecod 	= PlayerPrefs.GetInt("Time on Wave", 180);
			}
			if(PeopleSaved > PeopleRecord)
			{
				PlayerPrefs.SetInt("Innocent Saved", PeopleSaved);
				PeopleRecord 	= PlayerPrefs.GetInt("Innocent Saved", 50);
			}

			if(Input.GetButtonDown("Fire1"))
			{
				if(!isPaused)
				{
					PauseGame();
				}
			}
		}
		if(lifes <= 0 && !gameOverCheck)
		{
			Debug.Log("Is in Game Over");
			GameOver();
			gameOverCheck = true;
		}
	}
		
	#region GameOver / Restart Methods
	public void PauseGame()
	{
		isPaused = true;
		Time.timeScale = 0;

		if(PausedGame != null)
		{
			PausedGame(this,true);
		}
	}
	public void UnPuaseGame()
	{
		Time.timeScale = 1;
		if(PausedGame != null)
		{
			PausedGame(this, false);
		}

		Invoke("ChangeToUnPause", 1.0F);
	}

	void ChangeToUnPause()
	{		
		isPaused = false;
	}

	public void DisplayRewardAd()
	{
		if(Application.internetReachability == NetworkReachability.NotReachable)
		{
			Debug.LogError("There's no internet connection");
			return;
		}
		else
		{
			//AddManager ad_manager = FindObjectOfType<AddManager>() as AddManager;
			AddManager ad_manager = new AddManager();
			ad_manager.ShowAd();
		}
	}

	public void ContinueAfterDead()
	{
		lifes = 2;
		isGameOver = false;
		gameOverCheck = false;
		//DeadPanel dead_panel = FindObjectOfType<DeadPanel>() as DeadPanel;
		//dead_panel.DeActivatePanel();
		//StartCoroutine(WaitToContinue(3));	
		ContinuedAfterDead(this, true);
	}

	IEnumerator WaitToContinue(float time)
	{
		yield return new WaitForSecondsRealtime(time);
	}

	public void RestartGame()
	{
		Time.timeScale = 1;
		isGameOver = false;
		isPaused = false;
		SceneManager.LoadScene("Level00", LoadSceneMode.Single);
	}

	public void BackToMainMenu()
	{
		Character _char = GameObject.FindGameObjectWithTag("Player").GetComponent(typeof(Character)) as Character;
		_char.gameObject.layer = 10;
		SceneManager.LoadScene("_Main_Menu", LoadSceneMode.Single);
	}

	protected virtual void GameOver()
	{
		if(GameOvered != null)
		{
			GameOvered(this, EventArgs.Empty);
		}
		isGameOver = true;
	}
	#endregion

	#region Create Items / Dificult
	public static void AddPeopleSave(int value = 1)
	{
		PeopleSaved += value;
	}

	public void StartNumberOfItems(int value)
	{
		SetNumberOfItems(value);
	}
		
	IEnumerator SetDificult()
	{
		float _time = timePlaying;
		float _totalWaitingTime = DIFF_TIME_CONST + (_time * DIFF_CONST);
		float _checkWaitTime = _totalWaitingTime;

		do
		{
			SetNumberOfItems(dificulty);
			yield return new WaitForSeconds(CREAT_DELAY - (itemSpeed/3));
			_checkWaitTime -= CREAT_DELAY;
		}
		while(_checkWaitTime/2 > 0.0F);
		dificulty --;
		dificulty = Mathf.Clamp(dificulty, 0, 13);
		_checkWaitTime = _totalWaitingTime;
		_checkWaitTime /= 4;

		do
		{
			SetNumberOfItems(dificulty);
			yield return new WaitForSeconds(CREAT_DELAY - (itemSpeed/3));
			_checkWaitTime -= CREAT_DELAY;
		}
		while(_checkWaitTime > 0.0F);
		dificulty += 3;
		dificulty = Mathf.Clamp(dificulty, 0, 13);
		_checkWaitTime = _totalWaitingTime;
		_checkWaitTime /= 8;

		do
		{
			SetNumberOfItems(dificulty);
			yield return new WaitForSeconds(CREAT_DELAY - (itemSpeed/3));
			_checkWaitTime -= CREAT_DELAY;
		}
		while(_checkWaitTime > 0.0F);
		dificulty --;
		dificulty = Mathf.Clamp(dificulty, 0, 13);

		StartCoroutine(SetDificult());
	}

	void SetNumberOfItems(int difficult)
	{
		int good, bad;
		good = UnityEngine.Random.Range(3,5);
		float badItemsOption = (difficult + (good/10)) / OBS_CONST;
		int roundBad, floorBad;
		roundBad = Mathf.RoundToInt(badItemsOption);
		floorBad = Mathf.CeilToInt(badItemsOption); ;
		bad = UnityEngine.Random.Range(floorBad, roundBad + 1);

		theMatrix.MatrixCreator(good, bad);
		theMatrix.InstantiateMatrix();
	}
	#endregion
}
	