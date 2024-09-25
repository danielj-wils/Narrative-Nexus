using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class MusicPersistence : MonoBehaviour
{
    public static MusicPersistence instance;

    private void Awake() 
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            Debug.Log("Music features Awake: created and marked as DontDestroyOnLoad.");
        }
    }
}
