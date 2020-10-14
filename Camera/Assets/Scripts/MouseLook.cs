using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyCameraController : MonoBehaviour
{
    [SerializeField] private float _sensitivity = 1.0f;

    void Update()
    {
        //var mouseX = Input.GetAxis("Mouse X");
        //var newRotation = transform.localEulerAngles;
        //newRotation.y += _sensitivity * mouseX;
        //transform.localEulerAngles = newRotation;
    
        var mouseY = Input.GetAxis("Mouse Y");
        Vector3 newRotation1 = transform.localEulerAngles;
        newRotation.x -= mouseY;
        Debug.Log(newRotation.x);
        transform.localEulerAngles = newRotation;
    }
}
