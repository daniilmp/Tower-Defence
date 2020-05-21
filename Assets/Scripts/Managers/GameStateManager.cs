using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStateManager : MonoBehaviour
{
    [SerializeField] private PlayerHealth playerHealth = null;

    public event Action GameOver;
    private bool _isGameOver = false;

    private void Start()
    {
        playerHealth.HealthChanged += OnHealthChange;

    }

    private void OnHealthChange(float currentHealth)
    {
        if( currentHealth <= 0)
        {
            GameOver();
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
    private void OnDestroy()
    {
        playerHealth.HealthChanged -= OnHealthChange;
    }
}
