using UnityEngine;

public class EnemyDeath : MonoBehaviour
{
    private Enemy enemyReference;
    private void Awake()
    {
        enemyReference = GetComponent<Enemy>();
    }
    public void Death()
    {
        FindObjectOfType<EnemySpawner>().Enemies.Remove(enemyReference);
        GameStateManager.Instance.AddKill();
        Destroy(gameObject);
    }
}

