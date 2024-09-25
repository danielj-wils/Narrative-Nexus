using UnityEngine;
using UnityEngine.Events;

public class EnemyManager : MonoBehaviour
{
    public static EnemyManager instance;

    public int enemiesKilled = 0;
    public UnityEvent enemyKilled;

    private EnemySpawner enemySpawner;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            //DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if (enemySpawner == null)
        {
            enemySpawner = FindObjectOfType<EnemySpawner>();
        }
    }

    public void IncrementEnemiesKilled()
    {
        enemiesKilled++;
        enemyKilled.Invoke();
        Debug.Log("Enemies killed overall: " + enemiesKilled);
    }

    public int GetEnemiesKilledCount()
    {
        return enemiesKilled;
    }

    public void ResetData()
    {
        enemiesKilled = 0;
    }


}
