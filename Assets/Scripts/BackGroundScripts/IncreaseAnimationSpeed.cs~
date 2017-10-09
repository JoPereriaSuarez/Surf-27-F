using UnityEngine;
using System.Collections;

public class IncreaseAnimationSpeed : MonoBehaviour
{
	Animator ani;

	void Start()
	{
		ani = GetComponent(typeof(Animator)) as Animator;
	}

	void Update()
	{
		ani.speed += Time.deltaTime/500;
	}
}

