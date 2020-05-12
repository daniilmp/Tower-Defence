using UnityEngine;

public class UpgradableEnemy : MonoBehaviour, IUpgradable
{
    [SerializeField] private float healthUpgradeValue = 1f, moveSpeedUpgradeValue = 0.2f;

    private HasHealth _hasHealth;
    private MoveOnPath _moveOnPath;
    private void Awake()
    {
        _hasHealth = GetComponent<HasHealth>();
        _moveOnPath = GetComponent<MoveOnPath>();
    }
    public void Upgrade()
    {
        if(_hasHealth)
            _hasHealth.StartHealth += healthUpgradeValue;
        if(_moveOnPath)
            _moveOnPath.Speed += moveSpeedUpgradeValue;
    }
}
