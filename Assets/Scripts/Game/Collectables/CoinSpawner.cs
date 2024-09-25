using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CoinSpawner : MonoBehaviour
{
    public static CoinSpawner instance;

    public GameObject yellowCoin;
    public GameObject greenCoin;
    public GameObject blueCoin;
    public GameObject redCoin;

    public Transform[] spawnPoints;

    private float yellowTimeBetweenSpawns;
    private float greenTimeBetweenSpawns;
    private float blueTimeBetweenSpawns;
    private float redTimeBetweenSpawns;

    private float yellowNextSpawnTime;
    private float greenNextSpawnTime;
    private float blueNextSpawnTime;
    private float redNextSpawnTime;

    [SerializeField] private int totalSpawnedCoins = 0;
    [SerializeField] private int totalSpawnedCoinsOnScreen = 0;

    [SerializeField] private float yellowBottomSpawnRange;
    [SerializeField] private float yellowTopSpawnRange;
    [SerializeField] private float greenBottomSpawnRange;
    [SerializeField] private float greenTopSpawnRange;
    [SerializeField] private float blueBottomSpawnRange;
    [SerializeField] private float blueTopSpawnRange;
    [SerializeField] private float redBottomSpawnRange;
    [SerializeField] private float redTopSpawnRange;

    [SerializeField] private int maxCoinsOnScreen = 4;
    [SerializeField] private int maxTotalSpawnedCoins = 10;
    
    [SerializeField] private float spawnRadius = 0.5f; // Radius to check if a spawn point is occupied

    void Start()
    {
        totalSpawnedCoins = 0;
        instance = this;
    }

    void Update()
    {
        if (totalSpawnedCoinsOnScreen < maxCoinsOnScreen && totalSpawnedCoins < maxTotalSpawnedCoins)
        {
            StartCoroutine(SpawnYellowCoin());
            StartCoroutine(SpawnGreenCoin());
            StartCoroutine(SpawnBlueCoin());
            StartCoroutine(SpawnRedCoin());
        }

        GameObject[] coins = GameObject.FindGameObjectsWithTag("Coin");

        if (totalSpawnedCoinsOnScreen != coins.Length)
        {
            totalSpawnedCoinsOnScreen = coins.Length;
        }
        
    }

    IEnumerator SpawnYellowCoin()
    {
        yield return new WaitForSeconds(2f);
        if (Time.time > yellowNextSpawnTime && totalSpawnedCoinsOnScreen < maxCoinsOnScreen && totalSpawnedCoins < maxTotalSpawnedCoins)
        {
            SpawnCoin(yellowCoin, yellowBottomSpawnRange, yellowTopSpawnRange, ref yellowNextSpawnTime);
        }
    }

    IEnumerator SpawnGreenCoin()
    {
        yield return new WaitForSeconds(4.3f);
        if (Time.time > greenNextSpawnTime && totalSpawnedCoinsOnScreen < maxCoinsOnScreen && totalSpawnedCoins < maxTotalSpawnedCoins)
        {
            SpawnCoin(greenCoin, greenBottomSpawnRange, greenTopSpawnRange, ref greenNextSpawnTime);
        }
    }

    IEnumerator SpawnBlueCoin()
    {
        yield return new WaitForSeconds(6.5f);
        if (Time.time > blueNextSpawnTime && totalSpawnedCoinsOnScreen < maxCoinsOnScreen && totalSpawnedCoins < maxTotalSpawnedCoins)
        {
            SpawnCoin(blueCoin, blueBottomSpawnRange, blueTopSpawnRange, ref blueNextSpawnTime);
        }
    }

    IEnumerator SpawnRedCoin()
    {
        yield return new WaitForSeconds(10.7f);
        if (Time.time > redNextSpawnTime && totalSpawnedCoinsOnScreen < maxCoinsOnScreen && totalSpawnedCoins < maxTotalSpawnedCoins)
        {
            SpawnCoin(redCoin, redBottomSpawnRange, redTopSpawnRange, ref redNextSpawnTime);
        }
    }

    private void SpawnCoin(GameObject coinPrefab, float bottomSpawnRange, float topSpawnRange, ref float nextSpawnTime)
    {
        int randomIndex = Random.Range(0, spawnPoints.Length);
        Vector3 spawnPosition = spawnPoints[randomIndex].position;

        // Check if the spawn position is occupied by another coin
        if (!IsSpawnPointOccupied(spawnPosition))
        {
            Instantiate(coinPrefab, spawnPosition, coinPrefab.transform.rotation);
            totalSpawnedCoins++;

            nextSpawnTime = Time.time + Random.Range(bottomSpawnRange, topSpawnRange);
        }
    }

    private bool IsSpawnPointOccupied(Vector3 spawnPosition)
    {
        Collider[] hitColliders = Physics.OverlapSphere(spawnPosition, spawnRadius);
        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.CompareTag("Coin"))
            {
                return true; // A coin is already present at this spawn point
            }
        }
        return false; // The spawn point is free
    }
}
