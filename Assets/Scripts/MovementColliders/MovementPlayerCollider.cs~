using UnityEngine;
using System.Collections;

[RequireComponent(typeof(BoxCollider2D))]
public abstract class MovementPlayerCollider : MonoBehaviour
{
	protected Character _char;

	void Start()
	{
		_char = FindObjectOfType<Character>();
	}

	protected abstract void OnCollide();
	protected abstract void OnCollideExit();

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.gameObject.tag == "Player")
		{
			OnCollide();
		}
	}
	void OnTriggerExit2D(Collider2D other)
	{
		if(other.gameObject.tag == "Player")
		{
			OnCollideExit();
		}
	}
}

