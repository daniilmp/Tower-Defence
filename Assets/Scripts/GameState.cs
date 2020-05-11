using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameState : MonoBehaviour
{
    public event Action<int> GameOver;
    private bool _isGameOver = false;
    private int _killCount = 0;
    private void Awake()
    {
        FindObjectOfType<HealthManager>().HealthChanged += OnHealthChange;
    }

    public void AddKill()
    {
        _killCount++;
    }

    private void OnHealthChange(float currentHealth)
    {
        if( currentHealth <= 0)
        {
            GameOver(_killCount);
            Time.timeScale = 0;
            _isGameOver = true;
        }
    }
    private void Update()
    {
        if (_isGameOver)
        {
            
            RestartGame();
        }
    }
    private void RestartGame()
    {
        if (Input.GetKey(KeyCode.KeypadEnter) || Input.GetKey("return"))
        {
            Time.timeScale = 1;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
