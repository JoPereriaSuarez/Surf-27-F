using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public abstract class AbsDisplayText : MonoBehaviour
{
	protected Text theText;

	protected virtual void Start()
	{
		theText = GetComponent(typeof(Text)) as Text;
	}

	protected abstract void DisplayText();

	void Update()
	{
		DisplayText();
	}
}

