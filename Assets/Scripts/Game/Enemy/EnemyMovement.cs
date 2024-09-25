using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float speedIncreaseInterval = 3f;
    [SerializeField] private float speedIncrement = 0.25f;
    [SerializeField] private float speedDifference = 0.3f;
    private float maxSpeed;

    private Coroutine slowEffectCoroutine;

    [SerializeField]
    private float _rotationSpeed;
    private Rigidbody2D _rigidbody;
    [SerializeField] private float _screenBorder;
    private PlayerAwarenessController _playerAwarenessController;
    private float _changeDirectionCooldown;
    private Vector2 _targetDirection;
    private Camera _camera;


    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _playerAwarenessController = GetComponent<PlayerAwarenessController>();
        _targetDirection = transform.up;
        _camera = Camera.main;
    }

    void Start()
    {  
        maxSpeed = PlayerMovement.instance.speed - speedDifference;
        speed = speed * DifficultyManager.instance.enemySpeedMultiplier;
        StartCoroutine(IncreaseSpeedPeriodically());
    }

    IEnumerator IncreaseSpeedPeriodically()
    {
        while (speed < maxSpeed)
        {
            yield return new WaitForSeconds(speedIncreaseInterval);
            speed += speedIncrement;

            // Ensure speed does not exceed maxSpeed
            if (speed > maxSpeed)
            {
                speed = maxSpeed;
            }
        }
    }

    private void FixedUpdate()
    {
        UpdateTargetDirection();
        RotateTowardsTarget();
        SetVelocity();
    }

    private void UpdateTargetDirection()
    {
        HandleRandomDirectionChange();
        HandlePlayerTargeting();
        HandleEnemyOffScreen();
    }

    private void HandleRandomDirectionChange()
    {
        _changeDirectionCooldown -= Time.deltaTime;
        if (_changeDirectionCooldown <= 0)
        {
            float angleChange = Random.Range(-90f, 90f);
            Quaternion rotation = Quaternion.AngleAxis(angleChange, transform.forward);
            _targetDirection = rotation * _targetDirection;

            _changeDirectionCooldown = Random.Range(1f, 5f);
        }
    }

    private void HandlePlayerTargeting()
    {
        if (_playerAwarenessController.AwareOfPlayer)
        {
            _targetDirection = _playerAwarenessController.DirectionToPlayer;
        }
    }

    private void HandleEnemyOffScreen()
    {
        Vector2 screenPosition = _camera.WorldToScreenPoint(transform.position);

        if ((screenPosition.x < _screenBorder && _targetDirection.x < 0) ||
            (screenPosition.x > _camera.pixelWidth - _screenBorder && _targetDirection.x > 0))
        {
            _targetDirection = new Vector2(-_targetDirection.x, _targetDirection.y);
        }

        if (screenPosition.y < _screenBorder && _targetDirection.y < 0 ||
            (screenPosition.y > _camera.pixelHeight - _screenBorder && _targetDirection.y > 0))
        {
            _targetDirection = new Vector2(_targetDirection.x, -_targetDirection.y);
        }
    }

    private void RotateTowardsTarget()
    {
        Quaternion targetRotation = Quaternion.LookRotation(transform.forward, _targetDirection);
        Quaternion rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, _rotationSpeed * Time.deltaTime);

        _rigidbody.SetRotation(rotation);
    }

    private void SetVelocity()
    {
        _rigidbody.velocity = transform.up * speed;
    }

    //public void TemporarySpeedDecrease(float speedAdjustment, float duration)
    //{
    //    StartCoroutine(TemporarySpeedDecreaseCoroutine(speedAdjustment, duration));
    //}
//
    //private IEnumerator TemporarySpeedDecreaseCoroutine(float speedAdjustment, float duration)
    //{
    //    speed -= speedAdjustment;     // Reduce the speed
//
    //    Debug.Log($"Speed decreased to {speed} for {duration} seconds.");
//
    //    yield return new WaitForSeconds(duration);  // Wait for the duration
//
    //    speed = originalSpeed;  // Restore the original speed
    //    Debug.Log($"Speed restored to {speed}.");
    //}

    public void ApplySlowEffect(float slowDownFactor, float duration)
    {
        if (slowEffectCoroutine != null)
        {
            StopCoroutine(slowEffectCoroutine); // Stop any existing slow effect coroutine
        }
        slowEffectCoroutine = StartCoroutine(SlowEffectCoroutine(slowDownFactor, duration));
    }

    private IEnumerator SlowEffectCoroutine(float slowDownFactor, float duration)
    {
        float originalSpeed = speed;
        speed = originalSpeed * slowDownFactor;
        Debug.Log("Speed is decreased by a factor of " + slowDownFactor);

        yield return new WaitForSeconds(duration);
        Debug.Log("Waited a total of " + duration + " seconds.");

        speed = originalSpeed; // Restore the original speed
        Debug.Log("Speed is restored to original speed: " + originalSpeed);
    }

    public float GetSpeed()
    {
        return speed;
    }

    public void SetSpeed(float newSpeed)
    {
        speed = newSpeed;
    }
}
