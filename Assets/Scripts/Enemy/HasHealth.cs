using UnityEngine;

public class HasHealth : MonoBehaviour, IHasHealth
{
    public float StartHealth { get => startHealth; set { startHealth = value; } }

    [SerializeField] private Healthbar healthBar = null;
    [Min(1)][SerializeField] private float startHealth = 10;
    
    private float _currentHealth;
    private IHasReward _hasReward;
    private IDeath _enemyDeath;
    private bool _isAlive = true;
    private PlayerKillCount _playerKillCount;
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
        if (_currentHealth <= 0 && _isAlive)
        {
            _isAlive = false;
            _hasReward?.GiveReward();
            _playerKillCount.AddKill();
            _enemyDeath?.Death();
        }
    }
    public void Initialize(PlayerKillCount playerKillCount)
    {
        _playerKillCount = playerKillCount;
    }
}

