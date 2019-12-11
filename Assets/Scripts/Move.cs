using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour {

	private int currentPosition = 0;
	public int maxPos = 3;
	public int minPos = -2;

	// Start is called before the first frame update
	void Start() { }

	// Update is called once per frame
	void Update() {
		if (Input.GetKeyDown(KeyCode.W)) {
			currentPosition = Mathf.Min(maxPos, currentPosition + 1);
		}
		if (Input.GetKeyDown(KeyCode.S)) {
			currentPosition = Mathf.Max(minPos, currentPosition - 1);
		}
		transform.position = Vector3.up * currentPosition;
	}
}