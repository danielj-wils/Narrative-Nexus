using UnityEngine;

public class EnemyDeath : MonoBehaviour
{
    public AudioClip enemyKilledSound;
    [SerializeField] private float enemyKilledVolume;

    void OnDestroy()
    {
        SoundFXManager.instance.PlayerSoundFXClip(enemyKilledSound, transform, enemyKilledVolume);
        if (EnemyManager.instance != null)
        {
            EnemyManager.instance.IncrementEnemiesKilled();
        }

        if (EnemySpawner.instance != null)
        {
            EnemySpawner.instance.OnEnemyKilled();
        }
    }
}
