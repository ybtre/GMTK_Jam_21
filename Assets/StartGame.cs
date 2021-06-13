using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour {
    [SerializeField] private LevelLoader levelLoader;
    [SerializeField] private GameObject startGameText;

    private GameObject textGameObject;
    
    private Vector3 textPos;

    private void Start() {
        textPos = new Vector3(-28f, 11f, 16f);
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.GetComponent<Player>()) {
            textGameObject = Instantiate(startGameText, textPos, Quaternion.identity);
        }
    }

    private void OnTriggerStay(Collider other) {
        if (other.gameObject.GetComponent<Player>()) {
            if (Input.GetKeyDown(KeyCode.E)) {
                levelLoader.LoadNextLevel();
            }
        }
    }

    private void OnTriggerExit(Collider other) {
        Destroy(textGameObject);
    }
}
