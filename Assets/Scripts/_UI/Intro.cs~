using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class Intro : MonoBehaviour
{
	public WaitPanel[] panels;
	public int panelStartMusic = 0;
	int counter;

	void Start()
	{
		#if UNITY_STANDALONE
		Cursor.visible = false;
		#endif
		counter = 0;
		Time.timeScale = 1;

		StartCoroutine(GoThroughPanels(panels[counter].timeWaiting));
	}

	IEnumerator GoThroughPanels(float waitingTime = 4)
	{
		for(int i = 0; i < panels.Length; i++)
		{
			if(i == counter)
			{
				panels[i].gameObject.SetActive(true);
				if(i == panelStartMusic)
				{
					GetComponent<AudioSource>().Play();
				}
				continue;
			}

			panels[i].gameObject.SetActive(false);
		}
		yield return new WaitForSeconds(waitingTime);
		if(counter >= panels.Length - 1)
		{
			GoMainMenu();
			yield break;
		}
		counter ++;
		counter = Mathf.Clamp(counter, 0, panels.Length -1);
		StartCoroutine(GoThroughPanels(panels[counter].timeWaiting));
	}

	public void GoMainMenu()
	{
		StopCoroutine("GoThroughPanels");
		SceneManager.LoadScene("_Main_Menu", LoadSceneMode.Single);
	}
}

