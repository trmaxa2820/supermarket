using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISelector : MonoBehaviour
{
    private Controller _mouseController;
    private ISelectable _currentSelectable;
    private Camera _camera;

    private void OnEnable()
    {
        _mouseController.Enable();
        _mouseController.UISelect.MouseClick.performed += ctx => SelectObject();
    }

    private void OnDisable()
    {
        _mouseController.Disable();
        _mouseController.UISelect.MouseClick.performed -= ctx => SelectObject();
    }

    private void Awake()
    {
        _mouseController = new Controller();
        _camera = Camera.main;
    }
    private void SelectObject()
    {
        Vector3 direction = GetRayDirection();
        Ray ray = new Ray(_camera.transform.position, direction);
       
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            if(hit.collider.TryGetComponent<ISelectable>(out ISelectable selectable))
            {
                if (_currentSelectable != null)
                    _currentSelectable.OnDeselected();

                _currentSelectable = selectable;
                _currentSelectable.OnSelected();
            }
        }
    }

    private Vector3 GetRayDirection()
    {
        Vector3 mousePosition = _mouseController.UISelect.MousePosition.ReadValue<Vector2>();
        mousePosition.z = 10;
        Vector3 worldPosition = _camera.ScreenToWorldPoint(mousePosition);

        Vector3 direction = worldPosition - _camera.transform.position;

        return direction;
    }
}
