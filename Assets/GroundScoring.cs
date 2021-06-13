using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundScoring : MonoBehaviour {
    
    [SerializeField] private int PropScore = 100;
    [SerializeField] private ScoreManager scoreMngr;

    private bool canAddToScore = true;
    private void OnCollisionEnter(Collision other) {
        if (other.collider.gameObject.layer == LayerMask.NameToLayer("Ground")) {
            if (canAddToScore) {
                Debug.Log("Prop: " + gameObject.name + " Collided with Ground");
                scoreMngr.AddToScore(PropScore, gameObject);
                canAddToScore = false;
            }
        }
    }
}
