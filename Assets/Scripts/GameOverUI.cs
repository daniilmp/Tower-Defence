using TMPro;
using UnityEngine;

public class GameOverUI : MonoBehaviour
{
    [SerializeField] private GameObject enemiesKilledText = null;
    private GameState _gameState;
    private void Awake()
    {
        _gameState = FindObjectOfType<GameState>();
        _gameState.GameOver += OnGameOver;
    }

    private void OnGameOver(int enemiesKilled)
    {
        enemiesKilledText.GetComponent<TextMeshProUGUI>().text = $"You killed { enemiesKilled } enemies";
        foreach (Transform childTransform in transform)
        {
            childTransform.gameObject.SetActive(true);
        }
    }
}
