using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Animator))]
public class Coin : MonoBehaviour
{
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void PlayEffect()
    {
        _animator.SetTrigger("Effect");
    }
    
    public void Die()
    {
        gameObject.SetActive(false);
    }
}
