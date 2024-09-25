using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameMenu : MonoBehaviour
{
    public static GameMenu instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject); 
        }
    }

    void Start()
    {
        gameObject.SetActive(false);
    }

    public void SetActive()
    {
        this.gameObject.SetActive(true);
    }

    //on play, loads the first scene (dungeon)
    //public void OnPlayButton()
    //{
    //    Debug.Log("Play button clicked, loading next scene...");
    //    gameObject.SetActive(false); // Hide the menu
    //    ScenesManager.instance.LoadNextScene();
    //}

    public void OnLavaButton()
    {
        Debug.Log("Lava button clicked, loading lava scene...");
        gameObject.SetActive(false); // Hide the menu
        //ScenesManager.instance.LoadNextScene();
        //ScenesManager.instance.LoadLava();
        ScenesManager.instance.LoadScene(ScenesManager.Scene.Lava);
    }

    public void OnMeadowButton()
    {
        Debug.Log("Meadow button clicked, loading Meadow scene...");
        gameObject.SetActive(false); // Hide the menu
        //ScenesManager.instance.LoadMeadow();
        ScenesManager.instance.LoadScene(ScenesManager.Scene.Meadow);
    }

    public void OnDungeonButton()
    {
        Debug.Log("Dungeon button clicked, loading dungeon scene...");
        gameObject.SetActive(false); // Hide the menu
        //ScenesManager.instance.LoadDungeon();
        ScenesManager.instance.LoadScene(ScenesManager.Scene.Dungeon);
    }
    
    public void OnUnderwaterButton()
    {
        Debug.Log("Underwater button clicked, loading underwater scene...");
        gameObject.SetActive(false); // Hide the menu
        //ScenesManager.instance.LoadUnderwater();
        ScenesManager.instance.LoadScene(ScenesManager.Scene.Underwater);
    }

    public void OnDesertButton()
    {
        Debug.Log("Desert button clicked, loading desert scene...");
        gameObject.SetActive(false); // Hide the menu
        //ScenesManager.instance.LoadDesert();
        ScenesManager.instance.LoadScene(ScenesManager.Scene.Desert);
    }

    public void OnForestButton()
    {
        Debug.Log("Forest button clicked, loading desert scene...");
        gameObject.SetActive(false); // Hide the menu
        //ScenesManager.instance.LoadForest();
        ScenesManager.instance.LoadScene(ScenesManager.Scene.Forest);
    }

    public void OnMountainButton()
    {
        Debug.Log("Mountain button clicked, loading mountain scene...");
        gameObject.SetActive(false); // Hide the menu
        //ScenesManager.instance.LoadMountain();
        ScenesManager.instance.LoadScene(ScenesManager.Scene.Mountain);
    }

    public void OnSnowButton()
    {
        Debug.Log("Snow button clicked, loading snow scene...");
        gameObject.SetActive(false); // Hide the menu
        //ScenesManager.instance.LoadSnow();
        ScenesManager.instance.LoadScene(ScenesManager.Scene.Snow);
    }

    public void OnCityButton()
    {
        Debug.Log("City button clicked, loading snow scene...");
        gameObject.SetActive(false); // Hide the menu
        //ScenesManager.instance.LoadCity();
        ScenesManager.instance.LoadScene(ScenesManager.Scene.City);
    }
    
    
    public void OnReplayButton()
    {
        Debug.Log("Replay button clicked, loading same scene again...");
        gameObject.SetActive(false); // Hide the menu
        ScenesManager.instance.ReloadScene();
        //ScenesManager.instance.LoadScene(ScenesManager.Scene.Dungeon);
    }
}
