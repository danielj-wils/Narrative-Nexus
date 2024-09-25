using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerInGameInfo : MonoBehaviour
{
    public static PlayerInGameInfo instance;

    public GameObject floatingTextPrefab; // The floating text prefab to instantiate
    public Transform FloatingTextSpawnPoint; // Where to spawn the floating text

    private int lastYellowCoinMilestone = 0;
    private int lastGreenCoinMilestone = 0;
    private int lastBlueCoinMilestone = 0;
    private int lastRedCoinMilestone = 0;

    void Start()
    {
        instance = this; // Initialize the instance reference
    }

    public void ShowFloatingText(string message, Color textColour)
    {
        Vector3 spawnPosition = FloatingTextSpawnPoint.position + new Vector3(0, 0f, 0);
        GameObject floatingTextInstance = Instantiate(floatingTextPrefab, spawnPosition, Quaternion.identity);

        // Set the text of the floating text
        TextMeshProUGUI textMesh = floatingTextInstance.GetComponentInChildren<TextMeshProUGUI>();
        if (textMesh != null)
        {
            textMesh.text = message;
            textMesh.color = textColour;
        }

        //Destroy(floatingTextInstance, 2f);
    }

    public void CheckCoinCount()
    {
        StartCoroutine(CoinCount());
    }

    public IEnumerator CoinCount()
    {

        if (CoinManager.instance == null)
        {
            Debug.LogError("CoinManager.instance is null. Ensure CoinManager is initialized.");
            yield break;
        }

        if (PlayerMovement.instance == null)
        {
            Debug.LogError("PlayerMovement.instance is null. Ensure PlayerMovement is initialized.");
            yield break;
        }

        if (PlayerShoot.instance == null)
        {
            Debug.LogError("PlayerShoot.instance is null. Ensure PlayerShoot is initialized.");
            yield break;
        }

        if (PlayerDamagedInvincibility.instance == null)
        {
            Debug.LogError("PlayerDamagedInvincibility.instance is null. Ensure PlayerDamagedInvincibility is initialized.");
            yield break;
        }

        yield return new WaitForSeconds(0.1f);

        int yellowCoins = CoinManager.instance.GetYellowCoinsCollected();
        int greenCoins = CoinManager.instance.GetGreenCoinsCollected();
        int blueCoins = CoinManager.instance.GetBlueCoinsCollected();
        int redCoins = CoinManager.instance.GetRedCoinsCollected();
        int totalCoins = CoinManager.instance.GetTotalCoinsCollected();

        // Check for yellow coin milestone
        if (yellowCoins >= lastYellowCoinMilestone + PlayerMovement.instance.coinsForSpeedIncrease)
        {
            ShowFloatingText("Speed Increase!", Color.yellow);
            lastYellowCoinMilestone = yellowCoins; // Update to the current count
        }

        // Check for green coin milestone
        if (greenCoins >= lastGreenCoinMilestone + PlayerMovement.instance.coinsForAgilityIncrease)
        {
            ShowFloatingText("Agility Increase!", Color.green);
            lastGreenCoinMilestone = greenCoins; // Update to the current count
        }

        // Check for blue coin milestone
        if (blueCoins >= lastBlueCoinMilestone + PlayerShoot.instance.GetCoinsForFireRateIncrease())
        {
            ShowFloatingText("Fire Rate Increase!", Color.blue);
            lastBlueCoinMilestone = blueCoins; // Update to the current count
        }

        // Check for red coin milestone
        if (redCoins >= lastRedCoinMilestone + PlayerDamagedInvincibility.instance.coinsForInvincibilityIncrease)
        {
            ShowFloatingText("Invincibility Increase!", Color.red);
            lastRedCoinMilestone = redCoins; // Update to the current count
        }

    }
}
