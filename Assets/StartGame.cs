using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour {
    [SerializeField] private LevelLoader levelLoader;

    private void OnTriggerStay(Collider other) {
        if (other.gameObject.GetComponent<Player>()) {
            if (Input.GetKeyDown(KeyCode.E)) {
                levelLoader.LoadNextLevel();
            }
        }
    }
}
