using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class RhythmManager : Singleton<RhythmManager> {

	public Track track;
	public bool doubleTime;
	public bool upbeat;

	[Tooltip("Milliseconds")]
	public float tolerance = 0.2f;
	private int index;
	private AudioSource audioSource;
	private float startTime = float.MaxValue;
	private float baseCadence;
	
	public event Action Beat;

	public float LastBeat {
		get;
		set;
	}

	public float NextBeat{
		get;
		set;
	}

	public float GetCadence() {
		float tmpCadence = doubleTime ? baseCadence / 2 : baseCadence;
		return tmpCadence;
	}
	
	private new void Awake() {
		base.Awake();
		
		audioSource = GetComponent<AudioSource>();
		audioSource.clip = track.song;
		audioSource.Stop();
		baseCadence = 60 / track.bpm;
		Beat += OnBeat;
	}

	void Start() {
		startTime = Time.time;
		NextBeat = startTime;
		audioSource.Play();
	}
	
	private void Update() {
		if (Time.time >= NextBeat) {
			Beat?.Invoke();
		}
	}

	private void OnBeat() {
		LastBeat = NextBeat;
		index++;
		float delta = upbeat ? index * GetCadence() + baseCadence / 2 : index * GetCadence();
		NextBeat = startTime + delta;
	}

}

