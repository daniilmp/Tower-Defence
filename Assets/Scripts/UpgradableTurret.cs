using UnityEngine;

public class UpgradableTurret : MonoBehaviour, IUpgradable
{
    [SerializeField] private float priceForUpgrade = 1, fireRateUpgradeValue = 0.05f, damageUpgradeValue = 0.2f;
    private GoldManager _goldManager;
    private void Awake()
    {
        _goldManager = FindObjectOfType<GoldManager>();
    }
    public void Upgrade()
    {
        if (_goldManager.CanSpend(priceForUpgrade))
        {
            _goldManager.SpendGold(priceForUpgrade);
            GetComponent<IHasStats>().FireRate -= fireRateUpgradeValue;
            GetComponent<IHasStats>().Damage += damageUpgradeValue;
        }
        else
        {
            Debug.Log("No gold");
            //Not Enough gold event
        }
    }
}
