using TMPro;
using UnityEngine;

public class GameOverUI : MonoBehaviour
{
    [SerializeField] private GameState gameStateManager = null;
    [SerializeField] private GameObject enemiesKilledText = null;
    [SerializeField] private PlayerKillCount playerKillCount = null;
    private void Awake()
    {
        gameStateManager.GameOver += OnGameOver;
    }

    private void OnGameOver()
    {
        enemiesKilledText.GetComponent<TextMeshProUGUI>().text = $"You killed { playerKillCount.GetKillCount() } enemies";
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
