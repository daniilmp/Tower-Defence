using System;
using UnityEngine;

public class GoldManager: Singleton<GoldManager>
{
    public event Action<float> GoldChanged;

    [SerializeField] private float gold = 0;
    public float Gold { get => gold; }
    
    public void AddGold(float amount)
    {
        gold += amount;
        GoldChanged(gold);
    }
    public void SpendGold(float amount)
    {
        if (amount <= gold)
        {
            gold -= amount;
            GoldChanged(gold);
        }
    }
    public bool CanSpend(float amount) => amount <= gold;

}
