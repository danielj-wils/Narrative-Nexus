using System.Collections;
using UnityEngine;

public class Shockwave : MonoBehaviour
{
    [SerializeField]
    private float shockwaveEffectDuration = 2f; // Duration the slow effect lasts on the enemy
    [SerializeField]
    private float slowDownFactor = 0.5f; // Factor by which to slow down the enemy

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if (collision.GetComponent<EnemyMovement>())
        {
            EnemyMovement enemy = collision.GetComponent<EnemyMovement>();
            WeaponManager.instance.IncrementSlowedEnemiesValue();
            enemy.ApplySlowEffect(slowDownFactor, shockwaveEffectDuration);
        }

        //Destroy(gameObject); // Destroy the shockwave immediately after triggering the effect
    }
}