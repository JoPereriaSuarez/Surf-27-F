using UnityEngine;
using System.Collections;

public class UpperCollider : MovementPlayerCollider
{
	#region implemented abstract members of MovementPlayerCollider

	protected override void OnCollide ()
	{
		_char.canMoveUp = false;
	}

	protected override void OnCollideExit ()
	{
		_char.canMoveUp = true;
	}

	#endregion
}

