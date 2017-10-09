using UnityEngine;
using System.Collections;

public class PausePanel : MonoBehaviour
{
	void Awake()
	{
		GameController controller = FindObjectOfType<GameController>() as GameController;
		controller.PausedGame += OnPauseGame;
	}

	void OnPauseGame(object source, bool value)
	{
		gameObject.SetActive(value);

		for(int i = 0; i < transform.childCount; i ++)
		{
			transform.GetChild(i).gameObject.SetActive(value);
		}
	}
}

