using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interaction : MonoBehaviour
{
    public bool IsActive;
    public Countdown Countdown;
    public GameObject OutlineObject;

    private void Start()
    {
        IsActive = false;
    }

    public void Interact()
    {
        if (IsActive)
        {
            EndInteractionCountdown();
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
