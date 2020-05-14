using System.Collections.Generic;
using UnityEngine;

public interface IEnemySpawner
{
    List<GameObject> Enemies { get; }

    void RemoveEnemy(GameObject enemyReference);
    void SpawnWave();
}