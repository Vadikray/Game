using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private SpriteRenderer _spriteRenderer;

    public event UnityAction<int, int> HealthChanged;
    public event UnityAction Died;
    public UnityEvent Action;

    private int _currentHealth;
    private bool _isHit = false;

    private void Start()
    {
        _currentHealth = _health;
        HealthChanged?.Invoke(_currentHealth, _health);
    }

    public void ApplyDamage(int damage)
    {
        if (!_isHit)
        {
            Action?.Invoke();
            _isHit = true;
            _currentHealth -= damage;
            HealthChanged?.Invoke(_currentHealth, _health);
            StartCoroutine(RecoveryIsHit());
            StartCoroutine(ColorChange());

            if (_currentHealth <= 0)
                Die();
        }
    }

    public void Die()
    {
        Died?.Invoke();
    }

    private IEnumerator RecoveryIsHit()
    {
        var waitForSeconds = new WaitForSeconds(0.4f);
        yield return waitForSeconds;
        _isHit = false;
    }

    private IEnumerator ColorChange()
    {
        var waitForSeconds = new WaitForSeconds(0.4f);
        _spriteRenderer.color = new Color(1F, 0F, 0F);

        yield return waitForSeconds;
        _spriteRenderer.color = new Color(1F, 1F, 1F);
    }
}