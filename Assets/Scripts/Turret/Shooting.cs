﻿using UnityEngine;
public class Shooting : MonoBehaviour, IHasStats, IShooting
{
    [Min(0.05f)][SerializeField] private float fireRate = 0.5f;
    [Min(0)][SerializeField] private float damage = 1;
    [Min(1)][SerializeField] private float range = 5;
    private float _currentBulletCooldown;
    private Transform _target;

    public float FireRate { get { return fireRate; } set { fireRate = value; } }
    public float Damage { get { return damage; } set { damage = value; } }
    public float Range { get { return range; } set { range = value; } }

    private void Awake()
    {
        _currentBulletCooldown = fireRate;
    }
    private void Update()
    {
        _currentBulletCooldown -= Time.deltaTime;
        if (_currentBulletCooldown <= 0)
        {
            if (_target && Vector3.Distance(_target.position, transform.position) <= range)
                Shoot(_target);
            _currentBulletCooldown = fireRate;
        }
    }
    public void ChangeTarget(Transform target)
    {
        _target = target;
    }

    private void Shoot(Transform target)
    {
        target.GetComponent<IHasHealth>()?.TakeDamage(damage);
    }

}
