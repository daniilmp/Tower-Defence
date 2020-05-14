using UnityEngine;

public class CanDealDamage : MonoBehaviour, ICanDealDamage
{
    [Min(0)][SerializeField] private float damageAmount = 1;
    public void Damage()
    {
        HealthManager.Instance.TakeDamage(damageAmount);
    }
}

