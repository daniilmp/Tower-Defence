public interface IHasHealth
{
    float StartHealth { get; set; }

    void Initialize(GameStateManager gameStateManager);
    void TakeDamage(float damageAmount);
}