using TMPro;
using UnityEngine;

public class HasUpgradableUI : MonoBehaviour, IHasUpgradableUI
{
    [SerializeField] private GameObject upgradeUIText = null, upgradeUI = null;
    public void UpdateUpgradePriceText(float upgradePrice)
    {
        upgradeUIText.GetComponent<TextMeshProUGUI>().text = $"Upgrade for { upgradePrice } gold";
    }
    public void SetActiveUpgradeUI(bool value)
    {
        upgradeUI.SetActive(value);
    }
}
