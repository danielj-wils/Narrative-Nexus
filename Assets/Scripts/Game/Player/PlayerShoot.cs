using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShoot : MonoBehaviour
{
    public static PlayerShoot instance;

    [SerializeField]
    private GameObject _bulletPrefab;
    [SerializeField]
    private float _bulletSpeed;

    [SerializeField]
    private Transform _gunOffset;
    
    [SerializeField]
    private float _timeBetweenShots;

    [SerializeField] public int bulletsFired = 0;

    private bool canShoot= true;
    private bool _fireContiniously;
    private bool _fireSingle;
    private float _lastFireTime;
    
    [SerializeField] private int lastCoinCount = 0;
    [SerializeField] public int coinsForFireRateIncrease = 50;
    [SerializeField] private float fireRateIncreaseAmount = 0.2f;

    public AudioClip rankUpSound;
    public AudioClip shootSound;
    [SerializeField] private float rankUpVolume = 1f;
    [SerializeField] private float shootVolume = 0.5f;
    
    private void Awake() 
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        // Initialize or reset variables as needed
        lastCoinCount = CoinManager.instance.GetBlueCoinsCollected();
    }

    void Update()
    {
        if (_fireContiniously || _fireSingle && canShoot)
        {
          float timeSinceLastFire = Time.time - _lastFireTime;    
          if (timeSinceLastFire >= _timeBetweenShots)
          {
            FireBullet();
            _lastFireTime = Time.time;
            _fireSingle = false;
          }
        }  
        
        int currentCoinCount = CoinManager.instance.GetBlueCoinsCollected();

          // Increase speed based on collected coins
          if (currentCoinCount >= coinsForFireRateIncrease)
          {
              int coinDifference = currentCoinCount - lastCoinCount;    
              if (coinDifference >= coinsForFireRateIncrease)
              {
                  int numberOfIncrements = coinDifference / coinsForFireRateIncrease;
                  _timeBetweenShots -= numberOfIncrements * fireRateIncreaseAmount;
                  SoundFXManager.instance.PlayerSoundFXClip(rankUpSound, transform, rankUpVolume);
                  lastCoinCount = currentCoinCount; // Update last coin count
              }
          }
    }

    private void FireBullet()
    {
        SoundFXManager.instance.PlayerSoundFXClip(shootSound, transform, shootVolume);
        GameObject bullet = Instantiate(_bulletPrefab, _gunOffset.position, transform.rotation);
        Rigidbody2D rigidbody = bullet.GetComponent<Rigidbody2D>();

        rigidbody.velocity = _bulletSpeed * transform.up;

        WeaponManager.instance.BulletCount();
    }

    private void OnFire(InputValue inputValue)
    {
        _fireContiniously = inputValue.isPressed;

        if (inputValue.isPressed)
        {
          _fireSingle = true;
        }
    }

    public int GetCoinsForFireRateIncrease()
    {
        return coinsForFireRateIncrease;
    }
}
