using UnityEngine;

public class CanDealDamage : MonoBehaviour, ICanDealDamage
{
    [SerializeField] private float damageAmount = 1;
    public void Damage()
    {
        HealthManager.Instance.TakeDamage(damageAmount);
    }
}

