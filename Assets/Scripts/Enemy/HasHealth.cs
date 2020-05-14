using UnityEngine;

public class HasHealth : MonoBehaviour, IHasHealth
{
    public float StartHealth { get => startHealth; set { startHealth = value; } }

    [SerializeField] private Healthbar healthBar = null;
    [SerializeField] private float startHealth = 10;

    private float _currentHealth;
    private IHasReward _hasReward;
    private IDeath _enemyDeath;

    private void Awake()
    {
        _hasReward = GetComponent<IHasReward>();
        _enemyDeath = GetComponent<IDeath>();
        _currentHealth = startHealth;
    }
    public void TakeDamage(float damageAmount)
    {
        _currentHealth -= damageAmount;
        healthBar.UpdateHealth(_currentHealth);
        if (_currentHealth <= 0)
        {
            _hasReward?.GiveReward();
            GameStateManager.Instance.AddKill();
            _enemyDeath?.Death();
        }
    }
}

