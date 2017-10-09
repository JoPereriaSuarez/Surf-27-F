using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifePanel : MonoBehaviour 
{
	GameController controller;
	Text theText;

	void Start()
	{
		controller = FindObjectOfType<GameController>() as GameController;
		theText = GetComponent(typeof(Text)) as Text;
	}

	void Update()
	{
		theText.text = "Lifes: " + controller.lifes.ToString();
	}
}
