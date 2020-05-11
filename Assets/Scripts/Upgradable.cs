using UnityEngine;

public class Upgradable : MonoBehaviour
{
    [SerializeField] private float priceForUpgrade = 1;
    private GoldManager _goldManager;
    private void Awake()
    {
        _goldManager = FindObjectOfType<GoldManager>();
    }
    public void Upgrade()
    {
        if (_goldManager.CanSpend(priceForUpgrade))
        {
            _goldManager.SpendGold(1);
            GetComponent<IHasStats>().FireRate -= 0.05f;
            GetComponent<IHasStats>().Damage += 0.2f;
        }
        else
        {
            Debug.Log("No gold");
            //Not Enough gold event
        }
    }
}
