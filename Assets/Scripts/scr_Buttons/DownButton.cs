#if UNITY_ANDROID
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class DownButton : AbstractButton
{
	private Character character;

	void Start()
	{
		character = GameObject.FindGameObjectWithTag("Player").
			GetComponent(typeof(Character)) as Character;
	}

	public override void IsPressed ()
	{
		character.Move((int)VerticalDirection.Down);
	}

	void Update()
	{
		if(isPressed)
		{
			IsPressed();
		}
	}
}
#endif
