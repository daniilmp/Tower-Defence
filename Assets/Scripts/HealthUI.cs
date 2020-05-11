using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HealthUI : MonoBehaviour
{
    private GameState _gameState;
    private TextMeshProUGUI _textMeshPro;
    private void Awake()
    {
        _gameState = FindObjectOfType<GameState>();
        _textMeshPro = GetComponent<TextMeshProUGUI>();
        ChangeHealth(_gameState.Health);
        _gameState.HealthChanged += ChangeHealth;
    }
    private void ChangeHealth(float health)
    {
        _textMeshPro.text = $"Health: { health }";
    }
    private void OnDestroy()
    {
        _gameState.HealthChanged -= ChangeHealth;
    }
}
