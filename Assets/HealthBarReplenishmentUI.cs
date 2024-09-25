using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarReplenishmentUI : MonoBehaviour

{
    [SerializeField] private UnityEngine.UI.Image healthBarReplenishmentForegroundImage;
    [SerializeField] private int coinsRequiredForHealthIncrease = 10;
    
    private int totalCoins;
    private int coinsCollectedForCurrentBar = 0;

    private void Update() 
    {
        totalCoins = CoinManager.instance.GetTotalCoinsCollected(); 
        UpdateHealthReplenishmentBar();   
    }

    public void UpdateHealthReplenishmentBar()
    {
        coinsCollectedForCurrentBar = totalCoins % coinsRequiredForHealthIncrease;
        healthBarReplenishmentForegroundImage.fillAmount = (float)coinsCollectedForCurrentBar / coinsRequiredForHealthIncrease;

    }
}
