using TMPro;
using UnityEngine;

public class GameOverUI : MonoBehaviour
{
    [SerializeField] private GameStateManager gameStateManager = null;
    [SerializeField] private GameObject enemiesKilledText = null;
    private void Awake()
    {
        gameStateManager.GameOver += OnGameOver;
    }

    private void OnGameOver(int enemiesKilled)
    {
        enemiesKilledText.GetComponent<TextMeshProUGUI>().text = $"You killed { enemiesKilled } enemies";
        foreach (Transform childTransform in transform)
        {
            childTransform.gameObject.SetActive(true);
        }
    }
    private void OnDestroy()
    {
        gameStateManager.GameOver -= OnGameOver;
    }
}
