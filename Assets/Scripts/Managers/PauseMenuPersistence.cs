using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class PauseMenuPersistence : MonoBehaviour
{
    public static PauseMenuPersistence instance;

    private void Awake() 
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            Debug.Log("Pause features Awake: created and marked as DontDestroyOnLoad.");
        }
    }
}
