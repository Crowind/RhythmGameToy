using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using Random = UnityEngine.Random;

public class EnemyMove : MonoBehaviour {

	public float speed;
	
	private float playerDistance;
	private float cadence;	
	
	private void Start() {
		
		cadence = RhythmManager.instance.GetCadence();
		playerDistance = transform.position.x;
		speed = playerDistance / (7 * cadence);
	}

	void Update() {
		transform.Translate( Time.deltaTime * speed * Vector3.left);
	}

	public void Kill() {
		ScoreManager.instance.Score += 50;
		transform.gameObject.SetActive(false);
		Destroy(this);
	}

	public void Trample() {
		
		ScoreManager.instance.Score = Mathf.Max(0, ScoreManager.instance.Score - 100);
		
	}
}