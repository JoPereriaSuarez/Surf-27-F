using UnityEngine;
using System.Collections;

public class OnInnocentRecord : AbsDisplayText
{
	#region implemented abstract members of AbsDisplayText
	protected override void DisplayText ()
	{
		theText.text = GameController.PeopleRecord.ToString();
	}
	#endregion
}

