using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {
   
   [SerializeField] private int TotalScore;
   [SerializeField] private Text scoreText;

   private void Update() {
      scoreText.text = TotalScore.ToString();
   }

   public void AddToScore(int amountToAdd) {
      TotalScore += amountToAdd;
   }

   public void RemoveFromScore(int amountToRemove) {
      TotalScore -= amountToRemove;
   }
}
