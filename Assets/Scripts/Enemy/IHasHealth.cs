public interface IHasHealth
{
    float StartHealth { get; set; }

    void Initialize(PlayerKillCount playerKillCount);
    void TakeDamage(float damageAmount);
}