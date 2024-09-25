using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemySpawner : MonoBehaviour
{
    public static EnemySpawner instance;

    public GameObject enemy;
    public Transform[] spawnPoints;
    private float timeBetweenSpawns;
    private float nextSpawnTime;

    [SerializeField] private int enemyCountOnScreen;
    [SerializeField] public int maxEnemyCountOnScreen;
    //[SerializeField] private int enemiesKilledCount;
    private int totalSpawnedEnemies;
    [SerializeField] public int maxEnemies;
    [SerializeField] private int minEnemyCount;
    [SerializeField] private int maxEnemyCount;

    [SerializeField] public float bottomSpawnRange;
    [SerializeField] public float topSpawnRange;
    [SerializeField] public float minBottomSpawnRange = 0.5f;
    [SerializeField] public float minTopSpawnRange = 1.5f;

    public UnityEvent allEnemiesKilled;
 
    void Start()
    {
        enemyCountOnScreen = 0;
        //enemiesKilledCount = 0;
        totalSpawnedEnemies = 0;
        maxEnemies = Random.Range(minEnemyCount, maxEnemyCount + 1);
        instance = this;

        maxEnemies = maxEnemies + DifficultyManager.instance.additionalEnemiesPerVisit * DifficultyManager.instance.sceneVisitCount;
        
        bottomSpawnRange = Mathf.Max(bottomSpawnRange * Mathf.Pow(DifficultyManager.instance.enemySpawnSpeedMultiplierCalculation, DifficultyManager.instance.sceneVisitCount), EnemySpawner.instance.minBottomSpawnRange);
        topSpawnRange = Mathf.Max(topSpawnRange * Mathf.Pow(DifficultyManager.instance.enemySpawnSpeedMultiplierCalculation, DifficultyManager.instance.sceneVisitCount), EnemySpawner.instance.minTopSpawnRange);
    }

    void Update()
    {
        if (enemyCountOnScreen < maxEnemyCountOnScreen && totalSpawnedEnemies < maxEnemies)
        {
            SpawnEnemy();
        }

        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        
        if (enemyCountOnScreen != enemies.Length)
        {
            enemyCountOnScreen = enemies.Length;
        }
//
    }

    void SpawnEnemy()
    {
        
        if (Time.time > nextSpawnTime)
        {
            int randomIndex = Random.Range(0, spawnPoints.Length);
            Vector3 spawnPosition = spawnPoints[randomIndex].position;
            Quaternion spawnRotation = enemy.transform.rotation;
            GameObject newEnemy = Instantiate(enemy, spawnPosition, spawnRotation);

            //enemyCountOnScreen++;
            totalSpawnedEnemies++;

            //StartCoroutine(IncreaseSpeedPeriodically(newEnemy, 10f));

            timeBetweenSpawns = Random.Range(bottomSpawnRange, topSpawnRange);
            nextSpawnTime = Time.time + timeBetweenSpawns;
        }
    }

    //IEnumerator IncreaseSpeedPeriodically(GameObject enemy, float interval)
    //{
    //    while (enemy != null) // Continue as long as the enemy exists
    //    {
    //        yield return new WaitForSeconds(interval);
//
    //        EnemyMovement enemyMovement = enemy.GetComponent<EnemyMovement>();
    //        if (enemyMovement != null)
    //        {
    //            enemyMovement.IncreaseEnemySpeed(0.2f); 
    //        }
    //    }
    //}

    public void OnEnemyKilled()
    {
        enemyCountOnScreen--;
        //enemiesKilledCount++;
        //Debug.Log("Enemies killed in this scene: " + enemiesKilledCount);

        if (enemyCountOnScreen == 0 && totalSpawnedEnemies >= maxEnemies)
        {
            allEnemiesKilled.Invoke();
            Debug.Log("All enemies have been killed in this scene");
        }
    }
}
