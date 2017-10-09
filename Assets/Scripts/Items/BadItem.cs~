using UnityEngine;
using System.Collections;

public class BadItem : AbsItem
{
	public uint stepsBack = 1;

	protected override void OnInteract (Character character)
	{
		gameObject.layer = 0;

		character.StartGetHit();
		character.MoveBackward(stepsBack);
		if(FindObjectOfType<PlayerSoundManager>() != null)
		{
			FindObjectOfType<PlayerSoundManager>().PlayBadSound();
		}
	}
}

