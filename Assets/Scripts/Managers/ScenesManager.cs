using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class ScenesManager : MonoBehaviour
{
    public static ScenesManager instance;
    public GameObject gameMenu;
    public TimeManager time;
    public float tempTimeTaken;

    public string previousScene;
    public string nextScene = "";

    private float sceneLoadTime;
    private float timeTaken;
    [SerializeField] private string uniqueScenesVisited = "";
    public int countOfUniqueScenesVisited;
    [SerializeField] private string allScenesVisited = "";

    public UnityEvent OnSceneLoaded;

    private void Start()
    {

    }

    private void Awake()
    {
        instance = this;
        if (OnSceneLoaded == null)
        {
            OnSceneLoaded = new UnityEvent();
        }
        uniqueScenesVisited = "Void";
        allScenesVisited = "Void";
        countOfUniqueScenesVisited = 1;
    }

    private void Update()
    {
        if (gameMenu == null)
        {
            FindObjectOfType<GameMenu>();
        }
    }

    public void OnAllEnemiesKilled()
    {
        //tempTimeTaken = TimeManager.instance.GetTimeTaken();
        //ShowGameMenu();
        GameMenu.instance.SetActive();
    }

    private void ShowGameMenu()
    {
          gameMenu.SetActive(true);
    }

    public enum Scene
    {
        MainMenu,
        Death,
        PlayerProfile,
        Tutorial,
        Void,
        Dungeon,
        Lava,
        Meadow,
        Underwater,
        Desert,
        Forest,
        Mountain,
        Snow,
        City
    }

    public void LoadScene(Scene scene)
    {
        previousScene = SceneManager.GetActiveScene().name;
        timeTaken = TimeManager.instance.timeTaken;
        gameMenu.SetActive(false);

        string sceneName = scene.ToString();
        SceneManager.LoadScene(sceneName);
        DifficultyManager.instance.IncreaseSceneVisitCount();
        DifficultyManager.instance.AdjustDifficulty();
        OnSceneLoaded.Invoke();
        StartCoroutine(SceneVisitedValues(sceneName));
    }

    private IEnumerator SceneVisitedValues(string sceneName)
    {
        yield return new WaitForSeconds(DelayAdvanceButton.instance.delayTime);
        
        if (!uniqueScenesVisited.Contains(sceneName))
        {
            if (!string.IsNullOrEmpty(uniqueScenesVisited))
            {
                uniqueScenesVisited += ", ";
            }
            uniqueScenesVisited += sceneName;
            countOfUniqueScenesVisited += 1;
        }
        if (!string.IsNullOrEmpty(allScenesVisited))
        {
            allScenesVisited += ", ";
        }
        allScenesVisited += sceneName;

        TimeManager.instance.ResetTimers();
    }


    //load new game or main menu
    public void LoadNewGame()
    {
        SceneManager.LoadScene(Scene.MainMenu.ToString());
        Debug.Log("Loading Main Menu");
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Debug.Log("Advancing to the next scene");
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Debug.Log("Replaying same scene");
    }

    public void LoadDeathScene()
    {
        SceneManager.LoadScene("Death");
        Debug.Log("Advancing to the death scene");
    }

    public bool IsDeathSceneLoaded()
    {
        return SceneManager.GetActiveScene().name == "Death";
    }

    public void LoadPlayerProfile()
    {
        SceneManager.LoadScene("PlayerProfile");
        Debug.Log("Advancing to the Player Profile scene");
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        Debug.Log("Advancing to the main menu scene");
    }

    public void LoadVoid()
    {
        SceneManager.LoadScene(Scene.Void.ToString());
        Debug.Log("Advancing to the The Void scene");
    }

    public void LoadTutorial()
    {
        SceneManager.LoadScene("Tutorial");
        Debug.Log("Advancing to the next scene");
    }

    public void LoadDungeon()
    {
        SceneManager.LoadScene(Scene.Dungeon.ToString());
        Debug.Log("Advancing to the dungeon scene");
    }

    public void LoadLava()
    {
        SceneManager.LoadScene(Scene.Lava.ToString());
        Debug.Log("Advancing to the lava scene");
    }

    public void LoadMeadow()
    {
        SceneManager.LoadScene(Scene.Meadow.ToString());
        Debug.Log("Advancing to the meadow scene");
    }

    public void LoadUnderwater()
    {
        SceneManager.LoadScene(Scene.Underwater.ToString());
        Debug.Log("Advancing to the underwater scene");
    }

    public void LoadDesert()
    {
        SceneManager.LoadScene(Scene.Desert.ToString());
        Debug.Log("Advancing to the desert scene");
    }

    public void LoadForest()
    {
        SceneManager.LoadScene(Scene.Forest.ToString());
        Debug.Log("Advancing to the forest scene");
    }

    public void LoadMountain()
    {
        SceneManager.LoadScene(Scene.Mountain.ToString());
        Debug.Log("Advancing to the mountain scene");
    }

    public void LoadSnow()
    {
        SceneManager.LoadScene(Scene.Snow.ToString());
        Debug.Log("Advancing to the snow scene");
    }

    public void LoadCity()
    {
        SceneManager.LoadScene(Scene.City.ToString());
        Debug.Log("Advancing to the city scene");
    }

    public string GetCurrentScene()
    {
        return SceneManager.GetActiveScene().name;
    }

    public string GetUniqueScenesVisited()
    {
        return uniqueScenesVisited;
    }

    public int GetCountUniqueScenesVisited()
    {
        return countOfUniqueScenesVisited;
    }

    public string GetPreviousScene()
    {
        return previousScene;
    }

    public string GetAllScenesVisited()
    {
        return allScenesVisited;
    }
}

