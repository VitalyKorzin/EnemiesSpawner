using System.Collections;
using UnityEngine;

public class EnemiesDispenser : MonoBehaviour
{
    [SerializeField] private bool _isDispensing;
    [SerializeField] private Transform _placeRespawns;
    [SerializeField] private Enemy[] _templatesEnemies;

    private EnemiesSpawner[] _enemiesSpawners;
    private int _currentIndexSpawner;

    private void Start()
    {
        InitializeEnemiesSpawners();
        StartCoroutine(Dispense());
    }

    private IEnumerator Dispense()
    {
        WaitForSeconds waitForTwoSeconds = new WaitForSeconds(2f);

        while (_isDispensing)
        {
            var enemiesSpawner = GetNextEnemiesSpawner();
            var enemy = GetRandomEnemy();
            enemiesSpawner.Spawn(enemy);
            yield return waitForTwoSeconds;
        }
    }

    private void InitializeEnemiesSpawners()
    {
        _enemiesSpawners = new EnemiesSpawner[_placeRespawns.childCount];

        for (int i = 0; i < _enemiesSpawners.Length; i++)
            _enemiesSpawners[i] = _placeRespawns.GetChild(i).GetComponent<EnemiesSpawner>();
    }

    private EnemiesSpawner GetNextEnemiesSpawner()
    {
        var enemiesSpawner = _enemiesSpawners[_currentIndexSpawner];
        SetCurrentIndexSpawner();
        return enemiesSpawner;
    }

    private void SetCurrentIndexSpawner()
    {
        _currentIndexSpawner++;

        if (_currentIndexSpawner == _enemiesSpawners.Length)
            _currentIndexSpawner = 0;
    }

    private Enemy GetRandomEnemy()
    {
        int randomIndexEnemy = Random.Range(0, _templatesEnemies.Length);
        return _templatesEnemies[randomIndexEnemy];
    }
}