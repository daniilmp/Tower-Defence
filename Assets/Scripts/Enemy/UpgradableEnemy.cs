using UnityEngine;

public class UpgradableEnemy : MonoBehaviour, IUpgradable
{
    [SerializeField] private float healthUpgradeValue = 1f, moveSpeedUpgradeValue = 0.2f;

    private IHasHealth _hasHealth;
    private IMove _moveOnPath;
    private void Awake()
    {
        _hasHealth = GetComponent<IHasHealth>();
        _moveOnPath = GetComponent<IMove>();
    }
    public void Upgrade()
    {
        if(_hasHealth != null)
            _hasHealth.StartHealth += healthUpgradeValue;
        if(_moveOnPath != null)
            _moveOnPath.Speed += moveSpeedUpgradeValue;
    }
}
