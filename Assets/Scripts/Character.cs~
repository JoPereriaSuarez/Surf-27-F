using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour 
{
	public float moveSpeed = 50.0F;
	public float pivotXOffset = 4.65F;
	public float grabTime = 0.5F;
	public float hitTime = 1.0F;

	public RuntimeAnimatorController normalAni;
	public RuntimeAnimatorController grabAni;

	private float pivotXPoint;

	private float angle;
	private float[] positions = new float[] {-6.5F, -5.5F, -4.5F, -3.5F};
	private int currentPosition = 1;

	public bool canMoveUp = true;
	public bool canMoveDown = true;

	public void StartGetHit()
	{
		StartCoroutine(GetHit(hitTime));
	}

	public void GrabItem()
	{
		if(!GameController.isGameOver)
		{
			StartCoroutine(GrabCoroutine());
		}
	}
	IEnumerator GrabCoroutine()
	{
		Animator ani_ = transform.GetChild(0).GetComponent(typeof(Animator)) as Animator;
		if(ani_.runtimeAnimatorController == grabAni)
		{
			yield break;
		}
		SpriteRenderer rend = transform.GetChild(0).GetComponent(typeof(SpriteRenderer)) as SpriteRenderer;
		Sprite oldSprite = rend.sprite;
		ani_.runtimeAnimatorController = grabAni;
		yield return new WaitForSeconds(grabTime);
		ani_.runtimeAnimatorController = normalAni;

		rend.sprite = oldSprite;
	}
	IEnumerator GetHit(float time)
	{
		gameObject.layer = 11;
		SpriteRenderer[] _rend = GetComponentsInChildren<SpriteRenderer>();
		int counter = 0;
		while(counter++ < time)
		{
			_rend[0].color = Color.red;
			_rend[1].color = Color.red;
			yield return new WaitForSeconds(0.25F);

			_rend[0].color = Color.white;
			_rend[1].color = Color.white;
			yield return new WaitForSeconds(0.25F);
		}

		if(FindObjectOfType<GameController>() != null && !GameController.isGameOver)
		{
			gameObject.layer = 10;
		}
	}

	#region Initialization Methods
	public void Start()
	{
		GameController controller = FindObjectOfType<GameController>() as GameController;
		controller.GameOvered += OnGameOver;
		controller.ContinuedAfterDead += OnContinueAfterAd;

		transform.position = new Vector3(positions[3], 0,-5);
		pivotXPoint = transform.position.x + pivotXOffset;
		gameObject.layer = 10;
		canMoveUp = true;
		canMoveDown = true;
	}
	#endregion

	#region Movement Methods
		
	public void Move(float direction)
	{
		if(!canMoveUp && direction > 0)
		{
			return;
		}
		else if(!canMoveDown && direction < 0)
		{
			return;
		}

		Quaternion rot = transform.rotation;
		// the pivot point (1st parameter) must be in somewhere else (move Horizontally Methods)
		transform.RotateAround(new Vector3(pivotXPoint, 0,transform.position.z),
			Vector3.forward, 
			Time.deltaTime * moveSpeed * -direction);
		transform.rotation = rot;
	}


	public void MoveForward(uint numberOfSteps = 1)
	{	
		int lastPosition = currentPosition;
		currentPosition += (int)numberOfSteps;
		currentPosition = Mathf.Clamp(currentPosition, 0, positions.Length -1);

		Vector3 position = transform.position;
		position.x -= positions[lastPosition] - positions[currentPosition];
		position.x = Mathf.Clamp(position.x, -8.5F, -1);
		transform.position = position;

		pivotXPoint = transform.position.x + pivotXOffset;
	}

	void OnGameOver (object source, EventArgs args)
	{
		gameObject.layer = 11;
		canMoveUp = false;
		canMoveDown = false;		
	}

	void OnContinueAfterAd (object source, bool value)
	{
		//transform.position = new Vector3(positions[3], 0,-5);
		//pivotXPoint = transform.position.x + pivotXOffset;
		gameObject.layer = 10;
		canMoveUp = true;
		canMoveDown = true;

		StartCoroutine(GetHit(5));
	}

	public void MoveBackward(uint numberOfSteps = 1)
	{

		GameController controller = FindObjectOfType<GameController>() as GameController;
		controller.lifes --;

		currentPosition -= (int)numberOfSteps;
		currentPosition = Mathf.Clamp(currentPosition, 0, positions.Length -1);

		Vector3 position = transform.position;
		position.x = positions[currentPosition];
		transform.position = position;

		pivotXPoint = transform.position.x + pivotXOffset;


	}
	#endregion
}
