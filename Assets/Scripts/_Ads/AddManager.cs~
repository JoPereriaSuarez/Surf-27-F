using UnityEngine;
using UnityEngine.Advertisements;
using System.Collections;

public class AddManager 
{
	public AddManager()
	{
		#if UNITY_ANDROID
		Debug.Log("Android Game ID is: " + Advertisement.gameId);
		#endif

		if(!Advertisement.isInitialized)
		{
			Advertisement.Initialize(Advertisement.gameId, true);
		}
	}

	void AdCallbackHandler(ShowResult result)
	{
		switch(result)
		{
			case ShowResult.Finished:
				Debug.Log("The ad has finished");
				GameController controller = UnityEngine.MonoBehaviour.FindObjectOfType<GameController>() as GameController;
				controller.ContinueAfterDead();
				break;
			case ShowResult.Skipped:
				Debug.Log("You won't recieve a reward");
				break;
			case ShowResult.Failed:
				Debug.Log("Eroor loading ad");
				break;
		}
	}

	public void ShowAd()
	{
		ShowOptions options = new ShowOptions();
		options.resultCallback = AdCallbackHandler;
		Advertisement.Show(options);
	}
}

