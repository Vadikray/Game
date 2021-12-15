using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class FierceTooth : MonoBehaviour
{
    [SerializeField] private float _speed;
    
    private Rigidbody2D _rigidbody;
    private Vector2 _direction;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        _rigidbody.velocity = new Vector2(_direction.x * _speed, _rigidbody.velocity.y);
        Flip();
    }

    public void SetDirection(Vector2 direction)
    {
        _direction = direction;
    }
    
    private void Flip()
    {
        if (_direction.x < 0)
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        else if (_direction.x > 0)
            transform.localRotation = Quaternion.Euler(0, 180, 0);
    }
}
