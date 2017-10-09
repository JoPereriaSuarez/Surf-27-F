using UnityEngine;
using System;
using System.Collections;

public class DeadPanel : MonoBehaviour
{
	public bool des_active = true;
	bool _des_active;

	void Awake()
	{
		GameController controller = FindObjectOfType<GameController>() as GameController;
		controller.GameOvered += OnGameOver;
		controller.ContinuedAfterDead += OnContinueAfterAd;
	}

	void Start()
	{
		_des_active = des_active;
	}

	public void DeActivatePanel()
	{

	}

	void OnContinueAfterAd(object source, bool value)
	{
		gameObject.SetActive(!value);

		for(int i = 0; i < transform.childCount; i ++)
		{
			transform.GetChild(i).gameObject.SetActive(!value);
		}
	}

	void OnGameOver(object source, EventArgs args)
	{
		gameObject.SetActive(_des_active);

		for(int i = 0; i < transform.childCount; i ++)
		{
			transform.GetChild(i).gameObject.SetActive(_des_active);
		}
	}
}

