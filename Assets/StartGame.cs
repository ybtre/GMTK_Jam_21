using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour {
    [SerializeField] private LevelLoader levelLoader;

    private void OnTriggerEnter(Collider other) {
        Debug.Log("TriggerEnter");
        if (other.gameObject.GetComponent<Player>()) {
            Debug.Log("TriggerEnter - Component");
            levelLoader.LoadNextLevel();
        }
    }
}
