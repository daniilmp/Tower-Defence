﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour, IEnemySpawner
{
    [SerializeField] private int enemyRandomIncrement = 4;
    [SerializeField] private float spawnCooldown = 4, cooldownBetweenWaves = 5;
    [SerializeField] private GameObject enemyPrefab = null;
    [SerializeField] private Path path = null;
    private int _currentWave = 1;
    public List<GameObject> Enemies { get; private set; }
    private void Awake()
    {
        Enemies = new List<GameObject>();
        SpawnWave();
    }
    public void SpawnWave()
    {
        StartCoroutine(EnemySpawn());
    }
    public void RemoveEnemy(GameObject enemyReference)
    {
        Enemies.Remove(enemyReference);
    }
    private IEnumerator EnemySpawn()
    {
        for (int i = 0; i < Random.Range(_currentWave, enemyRandomIncrement + _currentWave + 1); i++)
        {

            GameObject newEnemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity, transform);
            newEnemy.GetComponent<IMoveOnPath>()?.Initialize(path);
            if (_currentWave != 1)
                newEnemy.GetComponent<IUpgradable>()?.Upgrade();
            Enemies.Add(newEnemy);
            yield return new WaitForSeconds(spawnCooldown);
        }
        _currentWave++;
        Invoke("SpawnWave", cooldownBetweenWaves);
        yield break;
    }
}