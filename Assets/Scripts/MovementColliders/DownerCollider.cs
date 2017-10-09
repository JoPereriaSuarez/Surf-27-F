using UnityEngine;
using System.Collections;

public class DownerCollider : MovementPlayerCollider
{
	#region implemented abstract members of MovementPlayerCollider

	protected override void OnCollide ()
	{
		_char.canMoveDown = false;
	}

	protected override void OnCollideExit ()
	{
		_char.canMoveDown = true;
	}

	#endregion
}

