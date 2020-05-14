using UnityEngine;

public class EnemyDeath : MonoBehaviour, IDeath
{
    public void Death()
    {
        FindObjectOfType<EnemySpawner>().RemoveEnemy(gameObject);
        Destroy(gameObject);
    }
}

