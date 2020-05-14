public interface IHasHealth
{
    float StartHealth { get; set; }

    void TakeDamage(float damageAmount);
}