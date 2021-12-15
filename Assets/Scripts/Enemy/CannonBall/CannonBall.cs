using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class CannonBall : MonoBehaviour
{
    [SerializeField] private int _damage;

    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Player player))
        {
            player.ApplyDamage(_damage);
        }

        Explosion();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Explosion();
    }

    private void Die()
    {
        gameObject.SetActive(false);
    }

    private void Explosion()
    {
        _animator.SetTrigger("Explosion");
    }
}