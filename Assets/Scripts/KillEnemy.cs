using System;
using System.Collections;
using UnityEngine;

class KillEnemy : MonoBehaviour {


	public float range = 0.5f;
	
	public GameObject hitbox;
	public Material inactiveHitbox;
	public Material activeHitbox;
	
	private MeshRenderer meshRenderer;

	private void Awake() {
		meshRenderer = hitbox.GetComponent<MeshRenderer>();
	}

	private void Update() {

		hitbox.transform.localScale = 2 * range * Vector3.one;
		
		if (Input.GetKeyDown(KeyCode.Space)) {
			StartCoroutine(ShowHitbox());
			Collider[] colliders = Physics.OverlapSphere(hitbox.transform.position, range);

			foreach (Collider col in colliders) {

				if (col.gameObject.CompareTag("Enemy")) {
					col.gameObject.GetComponent<EnemyMove>().Kill();
					if ( Time.time < RhythmManager.instance.LastBeat + RhythmManager.instance.tolerance ||  Time.time > RhythmManager.instance.NextBeat - RhythmManager.instance.tolerance    )  {
						Debug.Log("Great!");
					}
					else {
						Debug.Log("Meh...");
					}
				}
			}
		}
	}

    private IEnumerator ShowHitbox() {

		float startTime = Time.time;

		while ( Time.time<startTime + 0.1 ) {
			meshRenderer.material = activeHitbox;
			yield return null;
		}
		meshRenderer.material = inactiveHitbox;
	}

}