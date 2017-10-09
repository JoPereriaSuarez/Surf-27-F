#if UNITY_ANDROID
using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public abstract class AbstractButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
	protected bool isPressed;

	#region IPointerDown IPointerUp Implementation
	public void OnPointerDown(PointerEventData eventData)
	{
		isPressed = true;
	}
	public void OnPointerUp(PointerEventData eventData)
	{
		isPressed = false;
	}
	public abstract void IsPressed();
	#endregion
}
#endif