using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManagerPersistence : MonoBehaviour
{
    public static SceneManagerPersistence Instance;

    private void Awake() 
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            Debug.Log("Scene Manager Awake: created and marked as DontDestroyOnLoad.");
        }
    }
}
