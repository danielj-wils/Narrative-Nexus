using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public int score;
    public TextMeshProUGUI scoreText;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            //DontDestroyOnLoad(gameObject);
            //Debug.Log("ScoreManager Awake: instance created and marked as DontDestroyOnLoad.");
        }
        //else
        //{
        //    Destroy(gameObject);
        //    Debug.Log("ScoreManager Awake: instance already exists, destroying duplicate.");
        //}
    }

    public void AddScore(int amount)
    {
        score += amount;
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = score.ToString();
            Debug.Log("This is the current score: " + score.ToString());

        }
    }

    public float GetCurrentScore()
    {
        return score;
    }

    public void ResetScore()
    {
        score = 0;
    }
}
