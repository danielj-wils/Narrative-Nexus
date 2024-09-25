using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement instance;

    [SerializeField]
    public float speed;
    [SerializeField]
    private float rotationSpeed;
    [SerializeField] private float screenBorder;
    private Rigidbody2D _rigidbody;
    private Vector2 movementInput;
    private Vector2 smoothedMovementInput;
    private Vector2 movementInputSmoothVelocity;
    private Camera _camera;

    [SerializeField] private int lastCoinCountForSpeed = 0;
    [SerializeField] public int coinsForSpeedIncrease = 50;
    [SerializeField] private float speedIncreaseAmount = 0.2f;
    
    [SerializeField] private int lastCoinCountForAgility = 0;
    [SerializeField] public int coinsForAgilityIncrease = 50;
    [SerializeField] private float AgilityIncreaseAmount = 5f;

    public AudioClip rankUpSound;
    [SerializeField] private float volume = 1f;
    
    private void Awake() 
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        AssignMainCamera();
         
        if (instance == null)
        {
            instance = this;
            //DontDestroyOnLoad(gameObject);
        }
    }

    private void AssignMainCamera() 
    {
        _camera = Camera.main;
    }

    private void Start()
    {
        lastCoinCountForSpeed = CoinManager.instance.GetYellowCoinsCollected();
        lastCoinCountForAgility = CoinManager.instance.GetGreenCoinsCollected();
    }

    private void Update()
    {
        int currentCoinCountForSpeed = CoinManager.instance.GetYellowCoinsCollected();
        
        // Increase speed based on collected coins
        if (currentCoinCountForSpeed >= coinsForSpeedIncrease)
        {
            int coinDifference = currentCoinCountForSpeed - lastCoinCountForSpeed;

            if (coinDifference >= coinsForSpeedIncrease)
            {
                int numberOfIncrements = coinDifference / coinsForSpeedIncrease;
                speed += numberOfIncrements * speedIncreaseAmount;
                SoundFXManager.instance.PlayerSoundFXClip(rankUpSound, transform, volume);
                lastCoinCountForSpeed = currentCoinCountForSpeed; // Update last coin count
            }
        }
        
        int currentCoinCountForAgility = CoinManager.instance.GetGreenCoinsCollected();
        
        if (currentCoinCountForAgility >= coinsForAgilityIncrease)
        {
            int coinDifference = currentCoinCountForAgility - lastCoinCountForAgility;

            if (coinDifference >= coinsForAgilityIncrease)
            {
                int numberOfIncrements = coinDifference / coinsForAgilityIncrease;
                rotationSpeed += numberOfIncrements * AgilityIncreaseAmount;
                SoundFXManager.instance.PlayerSoundFXClip(rankUpSound, transform, volume);
                lastCoinCountForAgility = currentCoinCountForAgility; // Update last coin count
            }
        }
    }

    private void FixedUpdate() 
    {
        if (_camera == null) {
            AssignMainCamera();
        }

        SetPlayerVelocity();
        RotateInDirectionOfInput();
    }

    private void SetPlayerVelocity()
    {
        smoothedMovementInput = Vector2.SmoothDamp(smoothedMovementInput, movementInput, ref movementInputSmoothVelocity, 0.1f);
        
        _rigidbody.velocity = smoothedMovementInput * speed;
        PreventPlayerGoingOffScreen();
    }

    private void PreventPlayerGoingOffScreen()
    {
        Vector2 screenPosition = _camera.WorldToScreenPoint(transform.position);

        if ((screenPosition.x < screenBorder && _rigidbody.velocity.x < 0) || (screenPosition.x > _camera.pixelWidth - screenBorder && _rigidbody.velocity.x > 0))
        {
            _rigidbody.velocity = new Vector2(0, _rigidbody.velocity.y);  
        }

        if(screenPosition.y < 0 && _rigidbody.velocity.y < 0 || (screenPosition.y > _camera.pixelHeight - screenBorder && _rigidbody.velocity.y > 0))
        {
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, 0);  
        }
    }

    private void RotateInDirectionOfInput()
    {
        if (movementInput != Vector2.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(transform.forward, smoothedMovementInput);
            Quaternion rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
            
            _rigidbody.MoveRotation(rotation);
        }
    }

    private void OnMove(InputValue inputValue) {
        movementInput = inputValue.Get<Vector2>();
    }

    public float GetSpeed()
    {
        return speed;
    }
}
