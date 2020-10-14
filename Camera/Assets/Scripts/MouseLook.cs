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
        Debug.Log(newRotation.x);
        transform.localEulerAngles = newRotation;

        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            Zoom();
        }
    }

    private void Zoom()
    {
        GetComponent<Camera>().fieldOfView = _isZoomed ? 30 : 60;
        _isZoomed = !_isZoomed;
    }
}
