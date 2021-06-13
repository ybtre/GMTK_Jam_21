using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour {
   
   [SerializeField] private int TotalScore;

   public void AddToScore(int amountToAdd) {
      TotalScore += amountToAdd;
   }

   public void RemoveFromScore(int amountToRemove) {
      TotalScore -= amountToRemove;
   }
}
