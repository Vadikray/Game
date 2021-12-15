using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointPatrol : MonoBehaviour
{
    [SerializeField] private Transform[] _points;
    [SerializeField] private FierceTooth _fierceTooth;
    [SerializeField] private float _trashold;

    private int _currentPoint;

    private void Update()
    {
        if (IsOnPoint())
        {
            _currentPoint = (int) Mathf.Repeat(_currentPoint + 1, _points.Length);
        }

        var diraction = _points[_currentPoint].position - transform.position;
        diraction.y = 0;
        _fierceTooth.SetDirection((diraction.normalized));
    }

    private bool IsOnPoint()
    {
        return (_points[_currentPoint].position - transform.position).magnitude < _trashold;
    }
}
