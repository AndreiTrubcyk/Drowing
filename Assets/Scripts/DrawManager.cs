using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;

public class DrawManager : MonoBehaviour
{
    [SerializeField] private Image[] _chalks;
    [SerializeField] private Image _sponge;
    [SerializeField] private Pen _pen;
    [SerializeField] private LineRenderer _lineRendererPrefab;
    private List<LineRenderer> _lines = new();

    public void GetLine()
    {
        var line = Instantiate(_lineRendererPrefab);
        _pen.SetLine(line);
        _lines.Add(line);
    }

    public void GetColorFromButton(int index)
    {
        var color = _chalks[index].color;
        _pen.SetColor(color);
    }

    public void ClearAllLines()
    {
        if (_lines.Count != 0)
        {
            foreach (var line in _lines)
            {
                Destroy(line.gameObject);
            }
            _lines = new();
            SetLastLine();
        }
    }

    private void SetLastLine()
    {
        var last = Instantiate(_lineRendererPrefab);
        _pen.SetLine(last);
        _lines.Add(last);
        
    }

    private void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            SetLastLine();
        }
    }
}
