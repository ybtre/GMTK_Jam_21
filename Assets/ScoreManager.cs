using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {
   
   [SerializeField] private int TotalScore;
   [SerializeField] private Text scoreText;
    public GameObject FloatingText;

   private void Update() {
      scoreText.text = TotalScore.ToString();
   }

   public void AddToScore(int amountToAdd, GameObject callingObject) {
        TotalScore += amountToAdd;

        if (FloatingText != null)
        {
            var objTransform = callingObject.transform;
            var text = Instantiate(FloatingText, objTransform.position, Quaternion.identity);
            text.GetComponent<TextMesh>().text = amountToAdd.ToString();
        }

   }

   public void RemoveFromScore(int amountToRemove) {
      TotalScore -= amountToRemove;
   }
}
