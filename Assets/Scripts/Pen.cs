using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pen : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private Image _circle;
    [SerializeField] private Collider _board;
    private LineRenderer _lineRenderer;
    private Color _currentColor;

    public void SetColor(Color color)
    {
        _currentColor = color;
        _circle.color = _currentColor;
    }

    public void SetLine(LineRenderer lineRenderer)
    {
        _lineRenderer = lineRenderer;
        _lineRenderer.startColor = _currentColor;
        _lineRenderer.endColor = _currentColor;
    }

    private void Update()
    {
        var mousePosition = Input.mousePosition;
        CirclePosition(mousePosition);

        if (_lineRenderer == null || Input.GetMouseButtonDown(0))
        {
            return;
        }
        var mousePositionToWorld = _camera.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetMouseButton(0))
        {
            AddPoint(mousePositionToWorld);
        }
    }

    private void CirclePosition(Vector3 mousePosition)
    {
        mousePosition.x += 24;
        _circle.transform.position = mousePosition;
    }

    private void AddPoint(Vector3 mousePosition)
    {
        var ray = _camera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            if (hit.collider.CompareTag("hit"))
            {
                mousePosition.z = 0;
                _lineRenderer.positionCount ++;
                _lineRenderer.SetPosition(_lineRenderer.positionCount -1, mousePosition);
            }
            
        }
    }
}
