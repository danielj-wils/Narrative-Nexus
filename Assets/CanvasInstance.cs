using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasInstance : MonoBehaviour
{
    public static CanvasInstance instance;

    private void Awake()
    {
        instance = this;
        DontDestroyOnLoad(this);

        //if (ScenesManager.instance.OnSceneLoaded())
        //{
        //    this.gameObject.SetActive(true);
        //}
    }
}
