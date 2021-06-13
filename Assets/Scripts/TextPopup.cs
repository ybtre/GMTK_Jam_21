using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextPopup : MonoBehaviour
{
    public float PopupTime = 3f;
    void Start()
    {
        Destroy(gameObject, PopupTime);
        var PlayerCamera = FindObjectOfType<Camera>();
        transform.rotation = Quaternion.LookRotation(-PlayerCamera.transform.forward, PlayerCamera.transform.up);
    }
}
