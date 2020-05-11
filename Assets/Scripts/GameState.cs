using System;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameState : MonoBehaviour
{
    public float Health = 20;
    public event Action<float> HealthChanged;
    public event Action GameOver;
    private bool _isGameOver = false;
    public void Damage(float amount)
    {
        Health -= amount;
        HealthChanged(Health);
        if (Health <= 0)
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
}
