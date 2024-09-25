using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public static WeaponManager instance;

    public bool incrementBulletCount = true;
    [SerializeField] public int bulletsFired = 0;
    [SerializeField] public int bulletHit = 0;
    public int bulletMiss => bulletsFired - bulletHit;
    public float bulletAccuracy => bulletsFired > 0 ? (float)bulletHit / bulletsFired * 100 : 0;

    public float slowedEnemiesNumber = 0f;
    public float slowedEnemiesPerShockwave = 0f;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            //DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void startBulletCount()
    {
        incrementBulletCount = true;
    }

    public void stopBulletCount()
    {
        incrementBulletCount = false;
    }

    public void BulletCount()
    {
        if (incrementBulletCount)
        {
            bulletsFired++;
            Debug.Log("Bullets are counting");
        }
        else
        {
            Debug.Log("Bullets are not counting");
        }
    }

    public void BulletHit()
    {
        bulletHit++;
        Debug.Log("Bullet hit");
    }

    public int GetBulletsFired()
    {
        return bulletsFired;
    }

    public float GetBulletAccuracy()
    {
        return bulletAccuracy;
    }

    public void IncrementSlowedEnemiesValue()
    {
        slowedEnemiesNumber++;
    }

    public float GetSlowedEnemiesCount()
    {
        return slowedEnemiesNumber;
    }

    public float GetSlowedEnemiesPerShockwave()
    {
        slowedEnemiesPerShockwave = slowedEnemiesNumber / PlayerShockwave.instance.shockwavesUsed;
        return slowedEnemiesPerShockwave;
    }
}