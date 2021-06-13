using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndScreenScore : MonoBehaviour {

    public int score;
    public Text playerHUDScoreText;
    
    public Text scoreText;

    // Update is called once per frame
    void Update() {
        scoreText.text = playerHUDScoreText.text;
    }
}
