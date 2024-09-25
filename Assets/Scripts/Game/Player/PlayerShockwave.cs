using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShockwave : MonoBehaviour
{
    public static PlayerShockwave instance;

    [SerializeField]
    private GameObject shockwavePrefab;
    [SerializeField]
    private float shockwaveSpeed;
    [SerializeField]
    private float shockwaveDuration;
    [SerializeField]
    private Transform shockwaveOffset;
    [SerializeField]
    private float timeBetweenShockwaves = 10f; 
    private float timeUntilNextShockwave = 0f;

    private bool canFireShockwave = true;

    [SerializeField] private AudioClip smokeBombSound;
    [SerializeField] private float smokeBombVolume;

    public float shockwavesUsed = 0f;
    public float enemiesSlowed = 0f;
    private void Awake() 
    {
      instance = this;
    }
    
    void Update()
    {
        // If the player cannot fire a shockwave, start counting down
        if (!canFireShockwave)
        {
            timeUntilNextShockwave -= Time.deltaTime;

            // If the countdown is complete, reset the timer and allow the player to fire again
            if (timeUntilNextShockwave <= 0f)
            {
                timeUntilNextShockwave = 0f;
                canFireShockwave = true;
            }
        }

        
    }

    private void FireShockwave()
    {
        if (canFireShockwave)
        {
            SoundFXManager.instance.PlayerSoundFXClip(smokeBombSound, transform, smokeBombVolume);
            GameObject shockwave = Instantiate(shockwavePrefab, shockwaveOffset.position, transform.rotation);
            Rigidbody2D rigidbody = shockwave.GetComponent<Rigidbody2D>();
            shockwavesUsed++;

            // Start the countdown for the next shockwave
            timeUntilNextShockwave = timeBetweenShockwaves;
            canFireShockwave = false;

            StartCoroutine(RemoveShockwaveAfterTime(shockwaveDuration, shockwave));
        }
    }

    private IEnumerator RemoveShockwaveAfterTime(float time, GameObject shockwave)
    {
        yield return new WaitForSeconds(time);
        Destroy(shockwave);
    }

    private void OnShockwave(InputValue inputValue)
    {
        if (inputValue.isPressed && canFireShockwave)
        {
            FireShockwave();
        }
    }

    // Get the remaining cooldown time
    public float GetTimeUntilNextShockwave()
    {
        return timeUntilNextShockwave;
    }

    // Get the total cooldown duration between shockwaves
    public float GetTimeBetweenShockwave()
    {
        return timeBetweenShockwaves;
    }

    public float GetShockwavesUsed()
    {
        return shockwavesUsed;
    }

}
