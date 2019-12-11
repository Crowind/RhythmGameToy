using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RhythmMatChange : MonoBehaviour {

	public Material[] materials;
	
	private int index;
	private MeshRenderer meshRenderer;
	
	private void Start() {
		meshRenderer = GetComponent<MeshRenderer>();
		meshRenderer.material = materials[index];
		RhythmManager.instance.Beat += OnBeat;
	}

	private void OnBeat() {

		index = (index + 1) % 2;
		meshRenderer.material = materials[index];
	}

}