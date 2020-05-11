using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverUI : MonoBehaviour
{
    private GameState _gameState;
    private void Awake()
    {
        _gameState = FindObjectOfType<GameState>();
        _gameState.GameOver += OnGameOver;
    }

    private void OnGameOver()
    {
        foreach(Transform childTransform in transform)
        {
            childTransform.gameObject.SetActive(true);
        }
    }
}
