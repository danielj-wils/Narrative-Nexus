using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DifficultyManager : MonoBehaviour
{
    public static DifficultyManager instance;
    
    // Variables to track difficulty
    [SerializeField]public int sceneVisitCount = 0;
    [SerializeField]public float enemySpeedMultiplier = 1.0f;
    [SerializeField]public float enemySpeedMultiplierCalculation = 0.0025f;
    [SerializeField]public int additionalEnemiesPerVisit = 2;
    [SerializeField]public float enemySpawnSpeedMultiplierCalculation = 0.98f;

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

    private void Start()
    {
        PlayerPrefs.DeleteAll();

        SceneManager.sceneLoaded += OnSceneLoaded;
        
        sceneVisitCount = PlayerPrefs.GetInt("SceneVisitCount", 0);
        AdjustDifficulty();
    }

    private void OnDestroy()
    {
        // Unsubscribe from the sceneLoaded event
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        //IncreaseSceneVisitCount();
        AdjustDifficulty();
    }

    public void IncreaseSceneVisitCount()
    {
        sceneVisitCount++;
        PlayerPrefs.SetInt("SceneVisitCount", sceneVisitCount);
        AdjustDifficulty();
    }

    public void AdjustDifficulty()
    {
        enemySpeedMultiplier = 1.0f + (enemySpeedMultiplierCalculation * sceneVisitCount);  // Speed increases by 10% each visit
        //EnemySpawner.instance.maxEnemies += additionalEnemiesPerVisit * sceneVisitCount;
        //EnemySpawner.instance.bottomSpawnRange = Mathf.Max(EnemySpawner.instance.bottomSpawnRange * enemySpawnSpeedMultiplierCalculation, EnemySpawner.instance.minBottomSpawnRange);
        //EnemySpawner.instance.topSpawnRange = Mathf.Max(EnemySpawner.instance.topSpawnRange * enemySpawnSpeedMultiplierCalculation, EnemySpawner.instance.minTopSpawnRange);
    }
    
    public int GetSceneVisitCount()
    {
        return sceneVisitCount;
    }
}

