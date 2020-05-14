using TMPro;
using UnityEngine;

public class GameOverUI : MonoBehaviour
{
    [SerializeField] private GameObject enemiesKilledText = null;
    private void Awake()
    {
        GameStateManager.Instance.GameOver += OnGameOver;
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
        GameStateManager.Instance.GameOver -= OnGameOver;
    }
}
