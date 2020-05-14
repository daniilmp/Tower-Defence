using UnityEngine;
public class UpgradableTurret : MonoBehaviour, IUpgradable
{
    [SerializeField] private float upgradePrice = 1;
    [SerializeField] private float fireRateUpgradeValue = 0.05f;
    [SerializeField] private float damageUpgradeValue = 0.2f;
    [SerializeField] private float upgradePriceIncrement = 0.5f;
    [SerializeField] private float fireRateMax = 0.1f;

    private IHasUpgradableUI _upgradableUI;
    private IHasStats _hasStats;
    private void Awake()
    {
        _upgradableUI = GetComponent<IHasUpgradableUI>();
        _hasStats = GetComponent<IHasStats>();
        _upgradableUI?.UpdateUpgradePriceText(upgradePrice);
    }
    public void Upgrade()
    {
        if (GoldManager.Instance.CanSpend(upgradePrice))
        {
            GoldManager.Instance.SpendGold(upgradePrice);
            UpgradeStats();
            ChangeUpgradePrice();
        }
    }

    private void UpgradeStats()
    {
        if (_hasStats != null)
        {
            if (_hasStats.FireRate - fireRateUpgradeValue >= fireRateMax)
                _hasStats.FireRate -= fireRateUpgradeValue;
            _hasStats.Damage += damageUpgradeValue;
        }
    }

    private void ChangeUpgradePrice()
    {
        upgradePrice += upgradePriceIncrement;
        _upgradableUI?.UpdateUpgradePriceText(upgradePrice);
    }
 
}
