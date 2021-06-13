using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float timeRemaining = 60;
    public float maxTime = 60;
    [SerializeField] public Text timeText;
    [SerializeField] public GameObject timerBackground;
    public GameObject PlayerHud;
    public GameObject EndScreen;
    private Image img;

    private void Start() {
        img = timerBackground.GetComponent<Image>();
    }

    void Update()
    {
       if (timeRemaining > 0)
       {
           timeRemaining -= Time.deltaTime;
           DisplayTime(timeRemaining);
       }
       else {
           timeRemaining = 0;
           PlayerHud.SetActive(false);
           EndScreen.SetActive(true);
       }
       
       void DisplayTime(float timeToDisplay)
       {
           // timeToDisplay += 1;
           //
           // float seconds = Mathf.FloorToInt(timeToDisplay % 65);
           //
           // timeText.text = string.Format("{0:00}", seconds);

           var timePercent = timeRemaining / maxTime;
           img.fillAmount = timePercent;
       }
    }
}