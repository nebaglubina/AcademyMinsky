using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zoom : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private float _zoomValue;
    [SerializeField] private float _zoomSpeed = 3f;
    
    private float _defaultZoomValue;

    private bool _isZoomed = false;
    
    private void Start() {
        _zoomValue = _camera.fieldOfView / 2.0f;
        _defaultZoomValue = _camera.fieldOfView;
    }

    void Update() {
        if (Input.GetMouseButtonDown(1)) _isZoomed = !_isZoomed;

        if (_isZoomed) {
            MakeZoom(_camera.fieldOfView, _zoomValue);
        } else MakeZoom(_camera.fieldOfView, _defaultZoomValue);
    }

    private void MakeZoom(float from, float to) {
        _camera.fieldOfView = Mathf.Lerp(from, to, Time.deltaTime * _zoomSpeed);
    }
}
