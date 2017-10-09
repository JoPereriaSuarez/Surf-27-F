#if UNITY_STANDALONE
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PCPlayerMovement : MonoBehaviour 
{
	private Character character;

	void Start()
	{
		character = GameObject.FindGameObjectWithTag("Player").
			GetComponent(typeof(Character)) as Character;
	}

	void Update()
	{
		if(Input.GetAxis("Vertical") != 0.0F)
		{
			character.Move(Input.GetAxis("Vertical"));
		}
	}
}
#endif