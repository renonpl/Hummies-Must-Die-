﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour {

	public static bool MCExists;

	public AudioSource[] musicTracks;

	public int currentTrack;

	public bool musicOn;

	// Use this for initialization
	void Start () {
		if (!MCExists) {
			MCExists = true;
			DontDestroyOnLoad (transform.gameObject);
		}
		else
		{
			Destroy (gameObject);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (musicOn)
		{
			if (!musicTracks[currentTrack].isPlaying)
			{
				SwitchTrack (Random.Range (1, 4));
				musicTracks[currentTrack].Play ();
			}
		} 
		else 
		{
			musicTracks[currentTrack].Stop ();
		}
	}

	public void SwitchTrack(int newTrack)
	{
		musicTracks[currentTrack].Stop ();
		currentTrack = newTrack;
		musicTracks[currentTrack].Play ();
	}
}
