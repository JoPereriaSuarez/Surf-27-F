using UnityEngine;
using System.Collections;

public class OnInnocentSave : AbsDisplayText
{
	#region implemented abstract members of AbsDisplayText
	protected override void DisplayText ()
	{
		theText.text = GameController.PeopleSaved.ToString();
	}
	#endregion
	
}

