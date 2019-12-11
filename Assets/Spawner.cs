using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public GameObject spawn;
    
    void Start() {
        RhythmManager.instance.Beat += OnBeat;

    }

    private void OnBeat() {
        float rand = Random.Range(0f, 1f);
        if (rand > 0.55f) {
            GameObject enemy = Instantiate(spawn, transform.position, Quaternion.identity);
            enemy.transform.position = enemy.transform.position.x * Vector3.right + Random.Range(-2, 3) * Vector3.up;
            enemy.transform.parent = transform;
        }

    }
}
