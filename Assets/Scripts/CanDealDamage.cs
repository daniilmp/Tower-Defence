using UnityEngine;

public class CanDealDamage : MonoBehaviour
{
    [SerializeField] private float damageAmount = 1;
    public void Damage()
    {
        FindObjectOfType<GameState>().Damage(damageAmount);
    }
}

