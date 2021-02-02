using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMover : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _maxXPosition;
    [SerializeField] private float _minXPosition;
    [SerializeField] private float _maxZPosition;
    [SerializeField] private float _minZPosition;

    private Camera _camera;
    private Controller _controller;

    private void OnEnable()
    {
        _controller.Enable();
    }

    private void OnDisable()
    {
        _controller.Disable();        
    }

    private void Awake()
    {
        _controller = new Controller();
        _camera = Camera.main;
    }

    private void Update()
    {
        Vector3 normalizeDirection = GetNormalizeDirection(_controller.Camera.Move.ReadValue<Vector2>());
        MoveCam(normalizeDirection);
    }

    private void MoveCam(Vector3 normalizeDirection)
    {
        FixedDirectionByConditions(ref normalizeDirection);
        _camera.transform.position = transform.position + normalizeDirection;
    }

    private Vector3 GetNormalizeDirection(Vector2 direction)
    {
        Vector3 normalizeDirection;

        normalizeDirection.x = direction.x;
        normalizeDirection.z = direction.y;
        normalizeDirection.y = 0;

        normalizeDirection *= _moveSpeed * Time.deltaTime;

        return normalizeDirection;
    }

    private void FixedDirectionByConditions(ref Vector3 direction)
    {
        Vector3 currentPosition = _camera.transform.position;

        if ((currentPosition.x + direction.x) >= _maxXPosition || (currentPosition.x + direction.x) <= _minXPosition)
            direction.x = 0;

        if ((currentPosition.z + direction.z) >= _maxZPosition || (currentPosition.z + direction.z) <= _minZPosition)
            direction.z = 0;
    }
}
