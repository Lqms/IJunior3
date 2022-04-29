using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraZoom : MonoBehaviour
{
    [SerializeField] private float _maximalZoom = 4f;
    [SerializeField] private float _minimalZoom = 2f;
    [SerializeField] private float _currentZoom = 3f;

    private Camera _camera;

    private void Start()
    {
        _camera = GetComponent<Camera>();
    }

    void Update()
    {
        float zoomValue = Input.GetAxis("Mouse ScrollWheel");

        if (zoomValue != 0)
        {
            if (_currentZoom < _maximalZoom && zoomValue < 0)
            {
                _currentZoom++;
            }

            if (_currentZoom > _minimalZoom && zoomValue > 0)
            {
                _currentZoom--;
            }

            _camera.orthographicSize = _currentZoom;
        }
    }
}
