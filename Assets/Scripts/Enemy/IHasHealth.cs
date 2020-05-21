public interface IHasHealth
{
    float StartHealth { get; set; }

    void Initialize(IPlayerKillCount playerKillCount);
    void TakeDamage(float damageAmount);
}