using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    [SerializeField] private float _sensitivity = 3.0f;
    private bool _isZoomed = false;

    private void Update()
    {
        var mouseY = Input.GetAxis("Mouse Y");
        Vector3 newRotation = transform.localEulerAngles;
        newRotation.x -= mouseY * _sensitivity;
        transform.localEulerAngles = newRotation;
    }
}
