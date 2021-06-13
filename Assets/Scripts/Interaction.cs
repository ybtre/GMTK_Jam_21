using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interaction : MonoBehaviour {
    [SerializeField] private ScoreManager scoreMngr;

    private GroundScoring objScore;
    
    public bool IsActive;
    public Countdown Countdown;
    public GameObject OutlineObject;

    private void Start()
    {
        IsActive = false;
        objScore = GetComponent<GroundScoring>();
    }

    public void Interact()
    {
        if (IsActive)
        {
            EndInteractionCountdown();
            scoreMngr.AddToScore(objScore.PropScore * 2);
        }
    }

    public void StartInteractionCountdown()
    {
        IsActive = true;
        Countdown.StartCountdown();
        OutlineObject.SetActive(true);
    }

    public void EndInteractionCountdown()
    {
        Countdown.StopCountdown();
        OutlineObject.SetActive(false);
        IsActive = false;
    }
}
