using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class PlayerDamagedInvincibility : MonoBehaviour
{
    
    public static PlayerDamagedInvincibility instance;

    [SerializeField] private float invincibilityDuration;
    private Invincibility _invincibilityController;
    
    [SerializeField] private Color flashColour;
    [SerializeField] private int numberOfFlashes;

    [SerializeField] private int lastCoinCount = 0;
    [SerializeField] public int coinsForInvincibilityIncrease = 20;
    [SerializeField] private float InvicibilityIncreaseAmount = 0.5f;

    public AudioClip rankUpSound;
    [SerializeField] private float volume = 1f;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        _invincibilityController = GetComponent<Invincibility>();
    }

    private void Start()
    {
        // Initialize or reset variables as needed
        lastCoinCount = CoinManager.instance.GetRedCoinsCollected();
    }

    private void Update() 
    {
        int currentCoinCountForInvincibility = CoinManager.instance.GetRedCoinsCollected();
        
        // Increase speed based on collected coins
        if (currentCoinCountForInvincibility >= coinsForInvincibilityIncrease)
        {
            int coinDifference = currentCoinCountForInvincibility - lastCoinCount;

            if (coinDifference >= coinsForInvincibilityIncrease)
            {
                int numberOfIncrements = coinDifference / coinsForInvincibilityIncrease;
                invincibilityDuration += numberOfIncrements * InvicibilityIncreaseAmount;
                SoundFXManager.instance.PlayerSoundFXClip(rankUpSound, transform, volume);
                lastCoinCount = currentCoinCountForInvincibility; // Update last coin count
            }
        }
    }

    public void StartInvincibility()
    {
        _invincibilityController.StartInvincibility(invincibilityDuration, flashColour, numberOfFlashes);
    }
}
