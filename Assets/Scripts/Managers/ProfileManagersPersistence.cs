using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class ProfileManagersPersistence : MonoBehaviour
{
    public static ProfileManagersPersistence instance;
    
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            Debug.Log("Profile Managers' features Awake: created and marked as DontDestroyOnLoad.");
        }
    }
}
