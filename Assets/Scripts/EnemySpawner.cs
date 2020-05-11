using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private int enemyRandomIncrement = 4;
    [SerializeField] private float spawnCooldown = 4, cooldownBetweenWaves = 5;
    [SerializeField] private Enemy enemyPrefab = null;
    private int _currentWave = 5;
    public List<Enemy> Enemies;
    private void Awake()
    {
        SpawnWave();
    }
    void SpawnWave()
    {
        StartCoroutine(EnemySpawn());
    }
    private IEnumerator EnemySpawn()
    {
        for (int i = 0; i < Random.Range(_currentWave, enemyRandomIncrement + _currentWave + 1); i++)
        {
            Enemy newEnemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity, transform);
            Enemies.Add(newEnemy);
            yield return new WaitForSeconds(spawnCooldown);
        }
        _currentWave++;
        Invoke("SpawnWave", cooldownBetweenWaves);
        yield break;
    }
}
