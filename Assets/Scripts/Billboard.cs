using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    private Camera _playerCamera;

    // Start is called before the first frame update
    void Start()
    {
        _playerCamera = FindObjectOfType<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.LookRotation((transform.position - _playerCamera.transform.position), Vector3.up);
    }
}
