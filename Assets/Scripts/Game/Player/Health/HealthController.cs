using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class HealthController : MonoBehaviour
{
    public static HealthController instance; //{ get; private set;}

    [SerializeField] public float currentHealth;
    [SerializeField] public float _maximumhealth;

    public float RemainingHealthPercentage
    {
        get { return currentHealth / _maximumhealth;}
    }

    public bool isInvincible;

    public UnityEvent onDeath;
    public UnityEvent onDamage;
    public UnityEvent onHealthChanged;

    [SerializeField] private int coinCount = 0;
    [SerializeField] public int coinsForHealthIncrease = 10;
    [SerializeField] private int HealthIncreaseAmount = 10;

    public AudioClip healthUpSound;
    public AudioClip healthDownSound;
    [SerializeField] private float healthUpVolume = 1f;
    [SerializeField] private float healthDownVolume = 1.5f;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        // Initialize or reset variables as needed
        coinCount = CoinManager.instance.GetTotalCoinsCollected();
    }

    void Update()
    {
        int currentCoinCount = CoinManager.instance.GetTotalCoinsCollected();

        if (currentCoinCount >= coinsForHealthIncrease)
        {
          int coinDifference = currentCoinCount - coinCount;    
          if (coinDifference >= coinsForHealthIncrease)
          {
              AddHealth(HealthIncreaseAmount);
              SoundFXManager.instance.PlayerSoundFXClip(healthUpSound, transform, healthUpVolume);
              coinCount = currentCoinCount; 
          }
        }
    }

    public void TakeDamage(float damageAmount)
    {
        if (currentHealth == 0)
        {
            return;
        }

        if (isInvincible)
        {
            return;
        }

        currentHealth -= damageAmount;
        CameraShake.Shake(duration:0.5f, strength:0.25f);
        SoundFXManager.instance.PlayerSoundFXClip(healthDownSound, transform, healthDownVolume);
        onHealthChanged.Invoke();

        if (currentHealth < 0)
        {
            currentHealth = 0;
        }

        if (currentHealth == 0)
        {
            onDeath.Invoke();
        }
        
        else
        {
            onDamage.Invoke();
        }
    }

    public void AddHealth(float amountToAdd)
    {
        if (currentHealth == _maximumhealth)
        {
            return;
        }

        currentHealth += amountToAdd;
        onHealthChanged.Invoke();

        if (currentHealth > _maximumhealth)
        {
            currentHealth = _maximumhealth;
        }
    }

    public float GetCurrentHealth()
    {
        return currentHealth;
    }

    private void LoadDeathScene()
    {
        SceneManager.LoadScene("Death");
    }

}
