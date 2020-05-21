using System;

public interface IPlayerHealth
{
    float Health { get; }

    event Action<float> HealthChanged;

    void TakeDamage(float damageAmount);
}