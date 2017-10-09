using UnityEngine;
using System.Collections;

public class OnWaveTime : AbsDisplayText
{
	#region implemented abstract members of AbsDisplayText

	protected override void DisplayText ()
	{
		theText.text = ((GameController.TimeOnWave/60)).ToString("00") + ":" +
			((GameController.TimeOnWave%60)).ToString("00");
	}

	#endregion


}

