using UnityEngine;

public class EnemyState : MonoBehaviour
{
    public EnemySpawner spawner; 

    private void OnDestroy()
    {
      if (spawner != null)
      {
          spawner.OnEnemyKilled();
      }
    }

    // Method to destroy the enemy (example, can be called when health reaches 0)
    public void DestroyEnemy()
    {
        Destroy(gameObject);
    }
}
