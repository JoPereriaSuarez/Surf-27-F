using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfiniteBackground : MonoBehaviour {
	Material red;
	public float baseSpeed = 0.1F;
	public float speed = 0.1F;
	// Use this for initialization
	void Start () 
	{
		red = GetComponent<Renderer>().material;
	}

	// Update is called once per frame
	void Update() 
	{
		baseSpeed += Time.deltaTime/540;
		baseSpeed = Mathf.Clamp(baseSpeed, 0.0F, 0.6F);
		speed += Time.deltaTime * baseSpeed;
		red.mainTextureOffset = new Vector2(speed, 0f);
	}
}
