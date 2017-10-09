using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;

public class PanelController : MonoBehaviour
{
	public bool des_active = true;
	bool _des_active;

	void Awake()
	{
		GameController controller = FindObjectOfType<GameController>() as GameController;
		controller.GameOvered += OnGameOver;
		controller.PausedGame += OnPauseGame;
		controller.ContinuedAfterDead += OnContinueAfterAd;
	}

	void Start()
	{
		_des_active = des_active;
	}

	void OnContinueAfterAd(object source, bool value)
	{
		gameObject.SetActive(value);
		if(GetComponent(typeof(Image)))
		{
			GetComponent<Image>().enabled = true;	
		}

		for(int i = 0; i < transform.childCount; i ++)
		{
			transform.GetChild(i).gameObject.SetActive(value);
	
		}
	}

	void OnPauseGame(object source, bool value)
	{
		gameObject.SetActive(!value);

		for(int i = 0; i < transform.childCount; i ++)
		{
			transform.GetChild(i).gameObject.SetActive(!value);
		}	
	}

	void OnGameOver(object source, EventArgs args)
	{
		if(GetComponent(typeof(Image)))
		{
			GetComponent<Image>().enabled = _des_active;
		}

		for(int i = 0; i < transform.childCount; i ++)
		{
			transform.GetChild(i).gameObject.SetActive(_des_active);
		}
	}
}

