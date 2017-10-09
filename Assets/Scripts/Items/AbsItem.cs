using UnityEngine;
using System.Collections;


public abstract class AbsItem : MonoBehaviour
{
	[SerializeField]
	protected float moveSpeed = 3F;
	private float screenWidth;
	[SerializeField]
	protected AudioClip sfx;

	// Do sometthing when this item collide with the player
	protected abstract void OnInteract(Character character);

	protected virtual void Start()
	{
		transform.position = new Vector3(transform.position.x, transform.position.y, -5);
		moveSpeed += GameController.itemSpeed;

		Rigidbody2D rig;
		if(GetComponent<Rigidbody2D>() == null)
		{
			rig = gameObject.AddComponent(typeof(Rigidbody2D)) as Rigidbody2D;
		}
		else
		{
			rig = GetComponent(typeof(Rigidbody2D)) as Rigidbody2D;
		}
		rig.gravityScale = 0;
		screenWidth = -((Camera.main.orthographicSize * Camera.main.aspect) * 2);
		gameObject.layer = 9;

		if(FindObjectOfType<PlayerSoundManager>() != null)
		{
			AudioSource mySoundManager = FindObjectOfType<PlayerSoundManager>().itemsAudioSource;
			if(!mySoundManager.isPlaying && sfx != null)
			{
				mySoundManager.clip = sfx;
				mySoundManager.PlayDelayed(0.6F);
			}
		}
	}

	void Update()
	{
		if(transform.position.x < screenWidth)
		{
			GameObject.Destroy(this.gameObject);
		}
		transform.Translate(Vector2.left * Time.deltaTime * moveSpeed);
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		OnInteract(other.GetComponent<Character>());
	}
}

