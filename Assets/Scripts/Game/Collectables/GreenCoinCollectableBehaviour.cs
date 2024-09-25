using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenCoinCollectableBehaviour : MonoBehaviour, ICollectableBehaviour
{
    [SerializeField] private int scoreToAdd;
    public AudioClip coinSound;
    [SerializeField] private float volume;

    public void OnCollected(GameObject player)
    {
        SoundFXManager.instance.PlayerSoundFXClip(coinSound, transform, volume);
        CoinManager.instance.IncrementGreenCoinsCollected();

        if (ScoreManager.instance != null)
        {
            ScoreManager.instance.AddScore(scoreToAdd);
        }

        if (ScoreManager.instance != null)
        {
            CoinManager.instance.IncrementTotalCoinsCollected();
        }
    }
}
