using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class SceneLoader : MonoBehaviour
{
	public int sceneNumber = 0;

	void Start()
	{
		StartCoroutine(LoadCustomScene());
	}

	IEnumerator LoadCustomScene()
	{
		yield return new WaitForSecondsRealtime(1);

		AsyncOperation async_op = SceneManager.LoadSceneAsync(sceneNumber);

		while(!async_op.isDone)
		{
			yield return null;
		}
	}
}

