using UnityEngine;
using System.Collections;

public class OnWaveRecord : AbsDisplayText
{
	#region implemented abstract members of AbsDisplayText

	protected override void DisplayText ()
	{
		theText.text = ((GameController.TimeRecod/60)).ToString("00") + ":" +
			((GameController.TimeRecod % 60)).ToString("00");
	}

	#endregion
}

