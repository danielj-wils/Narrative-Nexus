using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Camera _camera;
    private EnemySpawner enemySpawner;
    private WeaponManager bulletManager;

    private void Awake() 
    {
        _camera = Camera.main;
        enemySpawner = FindObjectOfType<EnemySpawner>();
        bulletManager = WeaponManager.instance;
    }

    private void Update()
    {
        DestroyWhenOffScreen();
    }

    private void OnTriggerEnter2D(Collider2D collision) 
    {
           if (collision.GetComponent<EnemyMovement>())
           {
                bulletManager.BulletHit();

                Destroy(collision.gameObject);
                Destroy(gameObject);

                if (enemySpawner != null)
                {
                    enemySpawner.OnEnemyKilled();
                }
           } 
    }

   private void DestroyWhenOffScreen()
    {
        Vector2 screenPosition = _camera.WorldToScreenPoint(transform.position);

        if(screenPosition.x < 0 ||
            screenPosition.x > _camera.pixelWidth ||
            screenPosition.y < 0 ||
            screenPosition.y > _camera.pixelHeight)
        {
            Destroy(gameObject);
        } 
    }
}
