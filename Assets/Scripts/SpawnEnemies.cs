using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class SpawnEnemies : MonoBehaviour
{
    [SerializeField] private Transform _spawnPoints;
    [SerializeField] private GameObject _enemyGameObject;
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
            StartCoroutine();
    }

    private IEnumerator FadeIn()
    {
        var waitForSeconds = new WaitForSeconds(_frequencyOfSpawn);

        while (_currentPoint < _points.Length)
        {
            GameObject newEnemy = Instantiate(_enemyGameObject, _points[_currentPoint].position, Quaternion.identity);

            if(newEnemy.TryGetComponent(out Enemy enemy))
            {
                enemy.SetFrequencyValue(_frequencyOfSpawn);
            }

            _currentPoint++;

            yield return waitForSeconds;
        }
    }

    private void StartCoroutine()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(FadeIn());
    }
}
