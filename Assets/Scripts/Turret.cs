using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Turret : MonoBehaviour
{
    [SerializeField] private float lockOnTargetRange = 5, changeTargetCooldown = 1;
    
    private EnemySpawner _enemySpawner;
    private RotateToTarget _rotateToTarget;
    private IUpgradable _upgradable;
    private Shooting _shooting;
    private Enemy _target = null;
    private void Awake()
    {
        _enemySpawner = FindObjectOfType<EnemySpawner>();
        _shooting = GetComponent<Shooting>();
        _upgradable = GetComponent<IUpgradable>();
        _rotateToTarget = GetComponent<RotateToTarget>();
        StartCoroutine(ChangeTarget());
    }
    private void Update()
    {
        if (_target)
        {
            _rotateToTarget.ChangeTarget(_target.transform);
            _shooting.ChangeTarget(_target.transform);
        }
    }
    private IEnumerator ChangeTarget()
    {
        for (; ; )
        {
            _target = FindClosest();
            yield return new WaitForSeconds(changeTargetCooldown);
        }
    }
    private Enemy FindClosest()
    {
        float currentMin = Mathf.Infinity;
        Enemy target = null;
        foreach (Enemy enemy in _enemySpawner.Enemies)
        {
            float distanceToEnemy = Vector3.Distance(enemy.transform.position, transform.position);
            if (distanceToEnemy <= currentMin && distanceToEnemy <= lockOnTargetRange)
            {
                currentMin = distanceToEnemy;
                target = enemy;
            }
        }
        return target;
    }

    private void OnMouseUp()
    {
        _upgradable?.Upgrade();
    }
}
