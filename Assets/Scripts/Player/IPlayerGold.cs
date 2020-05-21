using System;

public interface IPlayerGold
{
    float Gold { get; }

    event Action<float> GoldChanged;

    void AddGold(float amount);
    bool CanSpend(float amount);
    void SpendGold(float amount);
}