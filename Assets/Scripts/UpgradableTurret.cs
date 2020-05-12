using UnityEngine;

public class UpgradableTurret : MonoBehaviour, IUpgradable
{
    [SerializeField] private float priceForUpgrade = 1, fireRateUpgradeValue = 0.05f, damageUpgradeValue = 0.2f;
    public void Upgrade()
    {
        if (GoldManager.Instance.CanSpend(priceForUpgrade))
        {
            GoldManager.Instance.SpendGold(priceForUpgrade);
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
