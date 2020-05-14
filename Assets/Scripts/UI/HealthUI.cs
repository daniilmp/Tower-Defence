using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HealthUI : MonoBehaviour
{
    private TextMeshProUGUI _textMeshPro;
    private void Awake()
    {
        _textMeshPro = GetComponent<TextMeshProUGUI>();
        
    }
    private void Start()
    {
        ChangeHealth(HealthManager.Instance.Health);
        HealthManager.Instance.HealthChanged += ChangeHealth;
    }
    private void ChangeHealth(float health)
    {
        _textMeshPro.text = $"Health: { health }";
    }
    private void OnDestroy()
    {
        HealthManager.Instance.HealthChanged -= ChangeHealth;
    }
}
