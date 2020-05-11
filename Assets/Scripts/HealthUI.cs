using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HealthUI : MonoBehaviour
{
    private HealthManager _healthManager;
    private TextMeshProUGUI _textMeshPro;
    private void Awake()
    {
        _healthManager = FindObjectOfType<HealthManager>();
        _textMeshPro = GetComponent<TextMeshProUGUI>();
        ChangeHealth(_healthManager.Health);
        _healthManager.HealthChanged += ChangeHealth;
    }
    private void ChangeHealth(float health)
    {
        _textMeshPro.text = $"Health: { health }";
    }
    private void OnDestroy()
    {
        _healthManager.HealthChanged -= ChangeHealth;
    }
}
