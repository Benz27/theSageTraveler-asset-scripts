using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleWithCamera : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private Vector3 _referenceScale = new Vector3(1f, 1f, 1f);
    [SerializeField] private float _referenceCameraSize = 5f;

    private void Start()
    {
        if (_camera == null)
        {
            _camera = Camera.main;
        }
    }

    private void Update()
    {
        float scaleFactor = _camera.orthographicSize / _referenceCameraSize;
        transform.localScale = new Vector3(
            _referenceScale.x * scaleFactor,
            _referenceScale.y * scaleFactor,
            _referenceScale.z * scaleFactor
        );
    }
}
