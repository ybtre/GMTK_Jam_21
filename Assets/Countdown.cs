using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Countdown : MonoBehaviour
{
    public float MaxTime = 5f;
    public Image ProgressImage;
    public Interaction InteractionComp;

    public Animator Animator;


    private float _elapsedTime;
    private bool _countdownEnabled = false;

    private void Start()
    {
        _elapsedTime = MaxTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (_countdownEnabled)
        {
            _elapsedTime -= Time.deltaTime;
            ProgressImage.fillAmount = _elapsedTime / MaxTime;

            // If the timer has expired.
            if (_elapsedTime <= 0f)
            {
                InteractionComp.EndInteractionCountdown();
            }
        }
    }

    public void StartCountdown()
    {
        _countdownEnabled = true;
        Animator.Play("Start");
    }

    public void StopCountdown()
    {
        _countdownEnabled = false;
        _elapsedTime = MaxTime;
        Animator.Play("Stop");
    }
}
