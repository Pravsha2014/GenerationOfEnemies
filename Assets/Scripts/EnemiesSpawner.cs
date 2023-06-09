using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesSpawner : MonoBehaviour
{
    [SerializeField] private Transform _spawnPoints;
    [SerializeField] private Enemy _enemy;
    [SerializeField] private float _frequencyOfSpawn;

    private Transform[] _points;
    private int _currentPoint;
    private Coroutine _coroutine;

    private void Start()
    {
        _points = _spawnPoints.GetComponentsInChildren<Transform>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            RunCoroutine();
    }

    private IEnumerator FadeIn()
    {
        var waitForSeconds = new WaitForSeconds(_frequencyOfSpawn);

        while (_currentPoint < _points.Length)
        {
            Enemy spawnedEnemy = Instantiate(_enemy, _points[_currentPoint].position, Quaternion.identity);

            if(spawnedEnemy.TryGetComponent(out Enemy enemy))
            {
                enemy.SetFrequencyValue(_frequencyOfSpawn);
            }

            _currentPoint++;

            yield return waitForSeconds;
        }
    }

    private void RunCoroutine()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(FadeIn());
    }
}
