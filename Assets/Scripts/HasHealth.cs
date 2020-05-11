using UnityEngine;

public class HasHealth : MonoBehaviour
{
    [SerializeField] private Healthbar healthBar = null;
    [SerializeField] private float startHealth = 10;

    private float _currentHealth;
    private HasReward _hasReward;
    private EnemyDeath _enemyDeath;

    private void Awake()
    {
        _hasReward = GetComponent<HasReward>();
        _enemyDeath = GetComponent<EnemyDeath>();
        _currentHealth = startHealth;
    }
    public void TakeDamage(float damageAmount)
    {
        _currentHealth -= damageAmount;
        healthBar.UpdateHealth(_currentHealth);
        if (_currentHealth <= 0)
        {
            _hasReward?.GiveReward();
            _enemyDeath?.Death();
        }
    }
}

