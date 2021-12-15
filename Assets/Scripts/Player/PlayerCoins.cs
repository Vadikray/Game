using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerCoins : MonoBehaviour
{
    private int _coinCount;

    public UnityEvent Action;
    public event UnityAction<int> CoinCollected;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Coin coin))
        {
            Action?.Invoke();
            _coinCount++;
            CoinCollected?.Invoke(_coinCount);
            coin.PlayEffect();
        }
    }
}