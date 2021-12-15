using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBallMover : MonoBehaviour
{
    [SerializeField] private int _speed;


    private void Update()
    {
        transform.Translate(Vector3.left * _speed * Time.deltaTime);
    }
}