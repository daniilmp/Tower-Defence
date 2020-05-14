using System.Collections;
using UnityEngine;

public class Turret : MonoBehaviour
{
    [Min(1)][SerializeField] private float lockOnTargetRange = 5;
    [Min(0.1f)][SerializeField] private float changeTargetCooldown = 1;
    private IEnemySpawner _enemySpawner;
    private IRotateToTarget _rotateToTarget;
    private IShooting _shooting;
    private GameObject _target = null;
    private void Awake()
    {
        _enemySpawner = FindObjectOfType<EnemySpawner>();
        _shooting = GetComponent<IShooting>();
        _rotateToTarget = GetComponent<IRotateToTarget>();
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
    // Loops through enemies list and finds the closest to turret enemy
    private GameObject FindClosest()
    {
        float currentMin = Mathf.Infinity;
        GameObject target = null;
        if (_enemySpawner.Enemies != null)
        {
            foreach (GameObject enemy in _enemySpawner.Enemies)
            {
                float distanceToEnemy = Vector3.Distance(enemy.transform.position, transform.position);
                if (distanceToEnemy <= currentMin && distanceToEnemy <= lockOnTargetRange)
                {
                    currentMin = distanceToEnemy;
                    target = enemy;
                }
            }
        }
        return target;
    }
}
