using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Spawner : ObjectPool
{
    [SerializeField] private GameObject _bombPrefab;
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private UnityEvent _spawn;

    private float _secondsBetweenSpawn;
    private float _elapsedTime = 0;
    private int _spawmPointNamber = 0;

    private void Start()
    {
        _secondsBetweenSpawn = Random.Range(1f, 5f);
        Initialize(_bombPrefab);
    }

    private void Update()
    {
        _elapsedTime += Time.deltaTime;

        if (_elapsedTime >= _secondsBetweenSpawn)
        {
            if (TryGetObject(out GameObject bomb))
            {
                _elapsedTime = 0;
                _secondsBetweenSpawn = Random.Range(1f, 5f);

                if (_spawmPointNamber <= _spawnPoints.Length)
                {
                    SetBomb(bomb, _spawnPoints[_spawmPointNamber].position);
                    _spawmPointNamber++;
                    _spawn?.Invoke();
                }

                if (_spawmPointNamber == _spawnPoints.Length)
                    _spawmPointNamber = 0;
            }
        }
    }

    private void SetBomb(GameObject bomb, Vector3 spawnPoint)
    {
        bomb.SetActive(true);
        bomb.transform.position = spawnPoint;
    }
}