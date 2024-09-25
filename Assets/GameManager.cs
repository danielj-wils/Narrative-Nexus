using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameObject player;

    private void Awake() 
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        //if (player = null)
        //{
            player = GameObject.FindGameObjectWithTag("Player");
        //}
    }

    void Update()
    {
        if (ScenesManager.instance.IsDeathSceneLoaded())
        {
            if (player != null)
            {
                Destroy(player);
                player = null;
            }
        }
    }
}
