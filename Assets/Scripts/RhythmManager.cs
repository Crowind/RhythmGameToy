using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class RhythmManager : Singleton<RhythmManager> {

	public Track track;
	public bool doubleTime;
	public bool upbeat;
	
	private int index;
	private AudioSource audioSource;
	private float startTime = float.MaxValue;
	private float cadence;
	
	public event Action Beat;
	
	private void Awake() {
		base.Awake();
		
		audioSource = GetComponent<AudioSource>();
		audioSource.clip = track.song;
		audioSource.Stop();
		cadence = 60 / track.bpm;
		Beat += OnBeat;
	}

	void Start() {
		startTime = Time.time;
		audioSource.Play();
	}

	void OnBeat() {
		index++;
	}
	
	private void Update() {

		float tmpCadence = doubleTime ? cadence / 2 : cadence;
		float delta = upbeat ? index * tmpCadence + cadence / 2 : index * tmpCadence;
		
		if (Time.time >= startTime + delta) {
			Beat?.Invoke();
		}
	}

	public float GetCadence() {
		float tmpCadence = doubleTime ? cadence / 2 : cadence;
		return tmpCadence;
	}
}

