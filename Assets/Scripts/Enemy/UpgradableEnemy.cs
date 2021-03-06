﻿using UnityEngine;

public class UpgradableEnemy : MonoBehaviour, IUpgradable
{
    [Min(0)][SerializeField] private float healthUpgradeValue = 1f;
    [Min(0)][SerializeField] private float moveSpeedUpgradeValue = 0.2f;

    private IHasHealth _hasHealth;
    private IMoveOnPath _moveOnPath;
    private void Awake()
    {
        _hasHealth = GetComponent<IHasHealth>();
        _moveOnPath = GetComponent<IMoveOnPath>();
    }
    public void Upgrade()
    {
        if(_hasHealth != null)
            _hasHealth.StartHealth += healthUpgradeValue;
        if(_moveOnPath != null)
            _moveOnPath.Speed += moveSpeedUpgradeValue;
    }
}
