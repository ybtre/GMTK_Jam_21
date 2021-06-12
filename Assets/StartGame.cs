using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour {
    [SerializeField] private LevelLoader levelLoader;

    private void OnTriggerStay(Collider other) {
        Debug.Log("TriggerEnter");
        if (other.gameObject.GetComponent<Player>()) {
            if (Input.GetKeyDown(KeyCode.E)) {
                Debug.Log("TriggerEnter - Component");
                levelLoader.LoadNextLevel();
            }
        }
    }
}
