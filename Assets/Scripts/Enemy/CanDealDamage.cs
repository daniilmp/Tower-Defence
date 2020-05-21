using UnityEngine;

public class CanDealDamage : MonoBehaviour, ICanDealDamage
{
    [Min(0)][SerializeField] private float damageAmount = 1;

    PlayerHealth _playerHealth;
    public void Initialize(PlayerHealth playerHealth)
    {
        _playerHealth = playerHealth;
    }
    public void Damage()
    {
        _playerHealth.TakeDamage(damageAmount);
    }
}

