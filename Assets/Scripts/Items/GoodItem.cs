using UnityEngine;
using System.Collections;

public class GoodItem : AbsItem
{
	public uint itemScore = 10;
	public uint stepsForward = 1;

	protected override void OnInteract (Character character)
	{
		character.MoveForward(stepsForward);
		gameObject.layer = 0;
		GameController.AddPeopleSave();
		//SpriteRenderer _rend = GetComponent(typeof(SpriteRenderer)) as SpriteRenderer;
		//_rend.enabled = false;

		if(FindObjectOfType<PlayerSoundManager>() != null)
		{
			FindObjectOfType<PlayerSoundManager>().PlayGoodSound();
		}
		character.GrabItem();
		GameObject.Destroy(this.gameObject, 0.34F);
	}
}

