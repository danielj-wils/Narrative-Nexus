using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class PlayerPersistence : MonoBehaviour
{
    public static PlayerPersistence instance;

    private void Awake() 
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            Debug.Log("Player features Awake: created and marked as DontDestroyOnLoad.");
        }
    }
}
