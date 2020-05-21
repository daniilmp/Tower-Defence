using TMPro;
using UnityEngine;

public class HealthUI : MonoBehaviour
{
    [SerializeField] private PlayerHealth playerHealth = null;
    private TextMeshProUGUI _textMeshPro;
    private void Awake()
    {
        _textMeshPro = GetComponent<TextMeshProUGUI>();
        
    }
    private void Start()
    {
        ChangeHealth(playerHealth.Health);
        playerHealth.HealthChanged += ChangeHealth;
    }
    private void ChangeHealth(float health)
    {
        _textMeshPro.text = $"Health: { health }";
    }
    private void OnDestroy()
    {
        playerHealth.HealthChanged -= ChangeHealth;
    }
}
