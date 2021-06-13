using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTargetScript : MonoBehaviour
{
    public Transform transformA;
    public Transform transformB;

    // Update is called once per frame
    void Update()
    {
        transform.position = transformB.position - transformA.position;
    }
}
