using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSoundManager : MonoBehaviour 
{
	private AudioClip positiveClip;
	private AudioClip negativeClip;
	private AudioClip gameOverSFX;

	public AudioSource feedBackAudioSource;
	public AudioSource musicAudioSource;
	public AudioSource itemsAudioSource;

	public AudioClip bg_music;

	void Awake()
	{		
		positiveClip = Resources.Load<AudioClip>("SFXResources/bien"); 
		negativeClip = Resources.Load<AudioClip>("SFXResources/mal");
		gameOverSFX = Resources.Load<AudioClip>("SFXResources/GameOverSFX");

		StartSoundManager();
	}

	void Start()
	{
		GameController controller = FindObjectOfType<GameController>() as GameController;
		controller.GameOvered += OnGameOver;
		controller.PausedGame += OnPauseAudio;
		controller.ContinuedAfterDead += OnContinueAfterAd;

		musicAudioSource.Play();
	}

	public void StartSoundManager()
	{
		feedBackAudioSource.playOnAwake = false;
		feedBackAudioSource.loop = false;
		feedBackAudioSource.priority = 10;
		feedBackAudioSource.clip = null;

		musicAudioSource.playOnAwake = false;
		musicAudioSource.loop = true;
		musicAudioSource.priority = 200;
		musicAudioSource.volume = 0.5F;
		musicAudioSource.clip = bg_music;

		itemsAudioSource.playOnAwake = false;
		itemsAudioSource.loop = false;
		itemsAudioSource.priority = 130;
		itemsAudioSource.clip = null;
	}

	void OnGameOver(object source, EventArgs args)
	{
		feedBackAudioSource.enabled = false;
		itemsAudioSource.enabled = false;
		musicAudioSource.Stop();
		musicAudioSource.clip = gameOverSFX;
		musicAudioSource.loop = false;
		musicAudioSource.volume = 1.0F;
		musicAudioSource.priority = 0;
		musicAudioSource.PlayDelayed(1);
	}

	void OnContinueAfterAd(object source, bool value)
	{
		feedBackAudioSource.enabled = true;
		itemsAudioSource.enabled 	= true;
		musicAudioSource.enabled 	= true;
		StartSoundManager();
		musicAudioSource.Play();
	}

	void OnPauseAudio(object source, bool value)
	{
		if(!value)
		{
			itemsAudioSource.UnPause();
			musicAudioSource.UnPause();
		}
		else
		{
			if(itemsAudioSource.isPlaying)
			{
				itemsAudioSource.Pause();
			}
			if(musicAudioSource.isPlaying)
			{
				musicAudioSource.Pause();
			}	
		}
	}

	public void PlayGoodSound()
	{
		feedBackAudioSource.clip = positiveClip;
		if(!feedBackAudioSource.isPlaying)
		{
			feedBackAudioSource.Play();
		}
	}

	public void PlayBadSound()
	{
		feedBackAudioSource.clip = negativeClip;
		if(!feedBackAudioSource.isPlaying)
		{
			feedBackAudioSource.Play();
		}
	}
}
