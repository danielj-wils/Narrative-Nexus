using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Vector3 = UnityEngine.Vector3;

public class CoinManager : MonoBehaviour
{
    public static CoinManager instance;

    public int totalCoinsCollected = 0;
    public int yellowCoinsCollected = 0;
    public int greenCoinsCollected = 0;
    public int blueCoinsCollected = 0;
    public int redCoinsCollected = 0;

    public TextMeshProUGUI yellowCoinText;
    public TextMeshProUGUI GreenCoinText;
    public TextMeshProUGUI BlueCoinText;
    public TextMeshProUGUI RedCoinText;

    private CoinSpawner coinSpawner;
    public static PlayerInGameInfo playerInGameInfo;
    
    public GameObject floatingTextPrefab; // The floating text prefab to instantiate
    public Transform FloatingTextSpawnPoint; // Where to spawn the floating text

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

        // Make sure PlayerInGameInfo is assigned
        playerInGameInfo = FindObjectOfType<PlayerInGameInfo>();
        if (playerInGameInfo == null)
        {
            Debug.LogError("PlayerInGameInfo not found in the scene!");
        }
    }

    private void Update()
    {
        if (coinSpawner == null)
        {
            coinSpawner = FindObjectOfType<CoinSpawner>();
        }

        yellowCoinText.text = yellowCoinsCollected.ToString();
        GreenCoinText.text = greenCoinsCollected.ToString();
        BlueCoinText.text = blueCoinsCollected.ToString();
        RedCoinText.text = redCoinsCollected.ToString();
    }

    public void IncrementTotalCoinsCollected()
    {
        totalCoinsCollected++;
        Debug.Log("Total coins collected: " + totalCoinsCollected);
        playerInGameInfo?.CheckCoinCount();
    }

    public void IncrementYellowCoinsCollected()
    {
        yellowCoinsCollected++;
        Debug.Log("Yellow coins collected: " + yellowCoinsCollected);
        playerInGameInfo?.CheckCoinCount();
    }

    public void IncrementGreenCoinsCollected()
    {
        greenCoinsCollected++;
        Debug.Log("Green coins collected: " + greenCoinsCollected);
        playerInGameInfo?.CheckCoinCount();
    }

    public void IncrementBlueCoinsCollected()
    {
        blueCoinsCollected++;
        Debug.Log("Blue coins collected: " + blueCoinsCollected);
        playerInGameInfo?.CheckCoinCount();
    }

    public void IncrementRedCoinsCollected()
    {
        redCoinsCollected++;
        Debug.Log("Red coins collected: " + redCoinsCollected);
        playerInGameInfo?.CheckCoinCount();
    }

    public int GetTotalCoinsCollected()
    {
        return totalCoinsCollected;
    }

    public int GetYellowCoinsCollected()
    {
        return yellowCoinsCollected;
    }

    public int GetGreenCoinsCollected()
    {
        return greenCoinsCollected;
    }

    public int GetBlueCoinsCollected()
    {
        return blueCoinsCollected;
    }

    public int GetRedCoinsCollected()
    {
        return redCoinsCollected;
    }

    public void ResetData()
    {
        totalCoinsCollected = 0;
        yellowCoinsCollected = 0;
        greenCoinsCollected = 0;
        blueCoinsCollected = 0;
        redCoinsCollected = 0;
    }
}
