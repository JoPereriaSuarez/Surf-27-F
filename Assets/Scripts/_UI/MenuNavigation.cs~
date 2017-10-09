using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public enum MenuDirection
{
	horizontal,
	vertical,
}

public class MenuNavigation : MonoBehaviour
{
	public Button[] buttons;
	public MenuDirection direction;
	private int counter = 0;

	//KeyCode positive, negative;
	string axis;
	public bool canNavigateTo = true;

	void Start()
	{
		canNavigateTo = true;
		switch(direction)
		{
			case MenuDirection.horizontal:
				axis = "Horizontal";
				break;

			case MenuDirection.vertical:
				axis = "Vertical";
				break;
		}
		print("initial axis " + axis);
		buttons[0].Select();
		
		/*buttons[0].Select();
		switch(direction)
		{
			case MenuDirection.horizontal:
				positive = KeyCode.D;
				negative = KeyCode.A;
				break;
			case MenuDirection.vertical:
				positive = KeyCode.S;
				negative = KeyCode.W;
				break;
		}*/
	}

	IEnumerator WaitToNavigate()
	{
		print("Start Coroutine");
		yield return new WaitForSecondsRealtime(0.5F);
		canNavigateTo = true;
	}

	void Update() 
	{
		if(Mathf.RoundToInt(Input.GetAxisRaw(axis)) != 0.0F && canNavigateTo)
		{
			counter -= (int)Input.GetAxisRaw(axis);
			print(counter);
			counter = Mathf.Clamp(counter,0,buttons.Length-1);

			buttons[counter].Select();
			StartCoroutine(WaitToNavigate());
			canNavigateTo = false;
		}
		/*if(Input.GetKeyUp(positive))
		{
			counter ++;
			counter = Mathf.Clamp(counter,0,buttons.Length-1);
			buttons[counter].Select();
		}
		else if(Input.GetKeyUp(negative))
		{
			counter --;
			counter = Mathf.Clamp(counter,0,buttons.Length-1);
			buttons[counter].Select();
		}*/
	}
}

