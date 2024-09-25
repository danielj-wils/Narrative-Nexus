using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueCoinCollectableBehaviour : MonoBehaviour, ICollectableBehaviour
{
    [SerializeField] private int scoreToAdd;
    public AudioClip coinSound;
    [SerializeField] private float volume;

    public void OnCollected(GameObject player)
    //{
    //    player.GetComponent<ScoreManager>().AddScore(scoreToAdd);
    //}
    //ScoreManager scoreManager = FindObjectOfType<ScoreManager>();
    {
        SoundFXManager.instance.PlayerSoundFXClip(coinSound, transform, volume);
        CoinManager.instance.IncrementBlueCoinsCollected();

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
