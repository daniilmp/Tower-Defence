using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour, IEnemySpawner
{
    [Min(0)][SerializeField] private int enemyRandomIncrement = 4;
    [Min(0)][SerializeField] private float spawnCooldown = 4;
    [SerializeField] private Config config = null;
    [SerializeField] private GameObject enemyPrefab = null;
    [SerializeField] private Path path = null;
    [SerializeField] private PlayerHealth playerHealth = null;

    private float _timeBetweenWaves = 0;
    private int _currentWave = 1;
    public List<GameObject> Enemies { get; private set; }
    private void Awake()
    {
        Enemies = new List<GameObject>();
        _timeBetweenWaves = config.TimeBetweenWaves; 
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
    // Spawns from K to K+X enemies each wave and invokes next wave spawn function
    private IEnumerator EnemySpawn()
    {
        for (int i = 0; i < Random.Range(_currentWave, enemyRandomIncrement + _currentWave + 1); i++)
        {
            GameObject newEnemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity, transform);
            newEnemy.GetComponent<IMoveOnPath>()?.Initialize(path);
            newEnemy.GetComponent<ICanDealDamage>()?.Initialize(playerHealth);
            if (_currentWave != 1)
                newEnemy.GetComponent<IUpgradable>()?.Upgrade();
            Enemies.Add(newEnemy);
            yield return new WaitForSeconds(spawnCooldown);
        }
        _currentWave++;
        Invoke(nameof(SpawnWave), _timeBetweenWaves);
        yield break;
    }
}


