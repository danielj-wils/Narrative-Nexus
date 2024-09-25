using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartMenu : MonoBehaviour
{
    public void OnPlayButton()
    {
        Debug.Log("Play button clicked, loading next scene...");
        ScenesManager.instance.LoadScene(ScenesManager.Scene.PlayerProfile);
    }

    // Called when we click the "Quit" button.
    public void OnQuitButton()
    {
        Debug.Log("Quit button clicked, quitting application...");
        Application.Quit();
    }

}
