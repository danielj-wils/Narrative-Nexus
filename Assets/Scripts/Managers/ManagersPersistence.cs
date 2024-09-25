using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class ManagersPersistence : MonoBehaviour
{
    public static ManagersPersistence instance;
    
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            Debug.Log("Managers' features Awake: created and marked as DontDestroyOnLoad.");
        }
    }
}
