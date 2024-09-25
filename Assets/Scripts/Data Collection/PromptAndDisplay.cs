using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using LLMUnity;
using System.Collections;

public class PromptAndDisplay : MonoBehaviour
{
    public static PromptAndDisplay instance;
    
    public Text zeroShotPromptText;
    public Text metaPromptText;
    
    public string zeroShotPrompt;
    public string metaPrompt;

    public static GameMenu gameMenu;
    public static ScenesManager scenes;
    public static DifficultyManager sceneCount;
    public static ScoreManager score;
    public static EnemyManager enemiesKilled;
    public static TimeManager timeTaken;
    public static HealthController health;
    public static WeaponManager weapon;
    public static CoinManager coins;
    public static PlayerShockwave shockwaves;

    public static ProfileManager playerName;
    public static ProfileManager playerAge;
    public static ProfileManager playerGender;
    public static ProfileManager characterName;

    private readonly float maxHealth = 100f;
    private readonly float minHealth = 0f;
    private readonly float maxWords = 225;
    private readonly float maxTokens = 225;

    //public ControlPromptActiveness controlPrompt;

    void Start()
    {
        //DontDestroyOnLoad(gameObject);
        StartCoroutine(InitializeAfterDelay());      
    }

    IEnumerator InitializeAfterDelay()
    {
        yield return new WaitForSeconds(0.2f); 

        //GenerateGameMetrics();
        //UpdateGameMetricsText(gameMetrics);
    
        //if (ScenesManager.Instance != null)
        //{
        //    ScenesManager.Instance.OnSceneLoaded.AddListener(OnSceneLoaded);
        //}  
    }

    void Update()
    {
        //continually find dependencies
        FindDependencies();
       
        //continually update game information
        //GenerateGameMetrics();
        //UpdateGameMetricsText(gameMetrics);
        

        //if (controlPrompt.gameObject.activeSelf)
        //{
        GenerateZeroShotPrompt();
        UpdateZeroShotPromptText(zeroShotPrompt);
        GenerateMetaPrompt();
        UpdateMetaPromptText(metaPrompt);
        //}

    }

    void GenerateZeroShotPrompt()
    {
        

        zeroShotPrompt =
            $"The player character {characterName.GetPlayerCharacterName()}, has just completed the {scenes.GetPreviousScene()} (previous) scene! They are now heading to the {scenes.GetCurrentScene()}(next) scene.\n\n" +
            $"Now you must create an interesting and diverse narrative to reflect this movement in scene using the third person and using the following game metric information to help craft and create the dialogue so it is personal:\n" +
            $"This game involves the player navigating through a series of rooms/scenes killing enemies. Once all the enemies in a room has been killed, the player has the choice of which room/scene to travel to next.\n\n" +
            $"UI // \n" +
            $"\tCurrent Score: {score.GetCurrentScore()}\n" +
            $"\tCurrent Health: {health.GetCurrentHealth()}\n" +
            $"(Minimum Health: {minHealth}, Maximum Health: {maxHealth})\n" +
            $"Player Health Percentage: {HealthController.instance.RemainingHealthPercentage * 100} percent.\n\n" +

            $"Collectables // \n" +
            $"\tCoins Collected in total: {coins.GetTotalCoinsCollected()}\n" +
            $"\t Yellow coins collected in total: {coins.GetYellowCoinsCollected()}\n" +
            $"\tGreen coins collected in total: {coins.GetGreenCoinsCollected()}\n " +
            $"\tBlue coins collected in total: {coins.GetBlueCoinsCollected()} \n " +
            $"\tRed coins collected in total: {coins.GetRedCoinsCollected()}\n\n " +

            $"Weapons // \n" +
            $"\tTotal Enemies Killed: {enemiesKilled.GetEnemiesKilledCount()}\n" +
            $"\tTotal Bullets Fired: {weapon.GetBulletsFired()}\n" +
            $"\tTotal Bullets Hit: {weapon.bulletHit} \n" +
            $"\tShooting Accuracy: {weapon.GetBulletAccuracy().ToString("F2")} percent\n" +
            $"\tSmokeBombs used: {shockwaves.GetShockwavesUsed()}.\n" +
            $"\tEnemies slowed from smokebombs: {weapon.GetSlowedEnemiesCount()}\n" +
            $"\tEnemies slowed per shockwave: {weapon.GetSlowedEnemiesPerShockwave()}\n\n" +
            
            $"Scenes // \n" +
            $"\tPrevious Scene: {scenes.GetPreviousScene()}\n" +
            $"\tCurrent Scene: {scenes.GetCurrentScene()}\n" +
            $"\tScenes Completed: {sceneCount.GetSceneVisitCount()}\n" +
            $"\tUnique Scenes Visited: {scenes.GetUniqueScenesVisited()}\n" +
            $"\tCount of Unique Scenes Visited: {scenes.GetCountUniqueScenesVisited()}\n" +
            $"\tAll Scenes Visited: {scenes.GetAllScenesVisited()}\n\n" +

            $"Misc // \n" +
            $"\tTime taken: {TimeManager.instance.timeTaken.ToString("F2")} seconds \n\n" +

            $"Generated Content Information and parameters (The following details and instructions should be followed)// \n" +
            $"\tEnsure the produced narrative does not stop in the middle of a word or sentence at the max word limit of {maxWords} words nor the max token limit of {maxTokens} tokens\n" +
            $"\tThis narrative does not need a title\n" +
            $"\tDo not use the percentage symbol ('%')- instead use the word 'percent' \n" +
            $"\tDo not explicitly use the players age or real name\n" +
            $"\tDo not confuse the real game player profile information with the game player information\n" +
            $"\tRemember to ensure the narrative is creative and not repetitive or redundant.\n\n" +

            $"Ensure the narrative includes vivid descriptions of the next destination scene, highlights Nexus's journey and actions, and reflects the transition from the previously travelled scene. Incorporate the player's achievements and challenges faced during the transition. The tone should reflect the inference of the game metrics and be immersive, capturing the player's experience and emotions.";
    }

    void GenerateMetaPrompt()
    {
  
        metaPrompt = $"The player character {characterName.GetPlayerCharacterName()}, has just completed the {scenes.GetPreviousScene()} (previous) scene! They are now heading to the {scenes.GetCurrentScene()}(next) scene.\n\n" +
                           $"Now you must create an interesting and diverse narrative to reflect this movement in scene using the third person and using the following game metric information to help craft and create the dialogue so it is personal:\n" +
                           $"This game involves the player navigating through a series of rooms/scenes killing enemies. Once all the enemies in a room has been killed, the player has the choice of which room/scene to travel to next.\n\n" +
                           $"UI // \n" + 
                           $"\tCurrent Score: {score.GetCurrentScore()}\n" +
                           $"\tThey start at 0 and the score can be endless.\n" +
                           $"\t{characterName.GetPlayerCharacterName()}'s current health stands at {health.GetCurrentHealth()}\n" +
                           $"\tThe maximum health {characterName.GetPlayerCharacterName()} can have is {maxHealth}.\n" +
                           $"\tTherefore, the players remaining health percentage is {HealthController.instance.RemainingHealthPercentage*100} percent.\n\n" +
                           $"\tWhen the player gets to 0 health, they die and the game ends.\n\n" +

                           $"Collectables // \n" +
                           $"\tThe player can pick up different coloured coins across the map which spawn periodically.\n" +
                           $"\tIn total, {characterName.GetPlayerCharacterName()} has picked up {coins.GetTotalCoinsCollected()} coins.\n" +
                           $"\tWhen the player collects a total of 10 coins, they recieve 10 health points (but maximum health caps at {maxHealth}).\n" +
                           $"\tThese coins have a rarity from lowest to highest in this order: yellow, green, blue and red. They also give the player different effects if they have collected a total of 20 of a certain colour:\n" +
                           $"\tSo far, {characterName.GetPlayerCharacterName()} has picked up {coins.GetYellowCoinsCollected()} yellow coins. The yellow coins increase the players speed everytime 10 are collected. This means they can move faster!\n" +
                           $"\tSo far, {characterName.GetPlayerCharacterName()} has picked up {coins.GetGreenCoinsCollected()} green coins. The green coins increase the players agility everytime 10 are collected. This means the player can rotate faster! \n" +
                           $"\tSo far, {characterName.GetPlayerCharacterName()} has picked up {coins.GetBlueCoinsCollected()} blue coins. The blue coins increase the players fire rate everytime 10 are collected. This means the player can shoot faster!\n" +
                           $"\tSo far, {characterName.GetPlayerCharacterName()} has picked up {coins.GetRedCoinsCollected()} red coins. The red coins increase the players invincibility timer when they are hit, everytime 10 are collected. This means they stay invincible for longer when they collide with an enemy!\n\n" +
                           
                           $"Weapons // \n" +
                           $"\tTotal Enemies Killed: {enemiesKilled.GetEnemiesKilledCount()}\n" +
                           $"\tTotal Bullets Fired: {weapon.GetBulletsFired()}\n" +
                           $"\tTotal Bullets Hit: {weapon.bulletHit} \n" +
                           $"\tShooting Accuracy: {weapon.GetBulletAccuracy().ToString("F2")} percent\n" +
                           $"\tThe player also has the option to use smoke bombs,which slows down the enemies caught in the range. They can only have a maximum of 1 smokebomb at any time. Once used, they have a 10 second reload timer.\n" +
                           $"\tIn total, {characterName.GetPlayerCharacterName()} has used {shockwaves.GetShockwavesUsed()} smokebombs.\n" +
                           $"\tIn total, {characterName.GetPlayerCharacterName()} has slowed down {weapon.GetSlowedEnemiesCount()} enemies using smokebombs.\n" +
                           $"\tEnemies slowed per shockwave: {weapon.GetSlowedEnemiesCount()/ shockwaves.GetShockwavesUsed()}\n\n" +
                           $"Scenes // \n" +
                           $"\tThe previous scene which the player has just visited was the {scenes.GetPreviousScene()} scene.\n" +
                           $"\tThey are now going into the {scenes.GetCurrentScene()} scene.\n" +
                           $"\tThe player has completed a total of {sceneCount.GetSceneVisitCount()} scenes.\n" +
                           $"\tThis is a list of all the unique scenes visited by the player: {scenes.GetUniqueScenesVisited()}\n" +
                           $"\tThis is a total of how many unique scenes have been visited: {scenes.GetCountUniqueScenesVisited()}\n" +
                           $"Misc // \n" +
                           $"\tThat scene took a total of {TimeManager.instance.timeTaken.ToString("F2")} seconds to kill all the enemies. \n" +
                           $"\tGenerated Content Information and parameters (The following details and instructions should be followed)// \n" +
                           $"\tEnsure the produced narrative does not stop in the middle of a word or sentence at the max word limit of {maxWords} words nor the max token limit of {maxTokens} tokens\n" +
                           $"\tThis narrative does not need a title\n" +
                           $"\tDo not use the percentage symbol ('%')- instead use the word 'percent' \n" +
                           $"\tDo not explicitly use the players age or real name\n" +
                           $"\tDo not confuse the real game player profile information with the game player information\n" +
                           $"\tRemember to ensure the narrative is creative and not repetitive or redundant.\n\n" +

                           $"Ensure the narrative includes vivid descriptions of the next destination scene, highlights Nexus's journey and actions, and reflects the transition from the previously travelled scene. Incorporate the player's achievements and challenges faced during the transition. The tone should reflect the inference of the game metrics and be immersive, capturing the player's experience and emotions.";
    }

    public void UpdateZeroShotPromptText(string prompt)
    {
        zeroShotPromptText.text = prompt;
    }

    public void UpdateMetaPromptText(string prompt)
    {
        metaPromptText.text = prompt;
    }

    public string GetZeroShotPrompt()
    {
        return zeroShotPromptText.text;
    }

    public string GetMetaPrompt()
    {
        return metaPromptText.text;
    }

    void FindDependencies()
    { 
        gameMenu = gameMenu ?? GameMenu.instance;
        scenes = scenes ?? ScenesManager.instance;
        score = score ?? ScoreManager.instance;
        enemiesKilled = enemiesKilled ?? EnemyManager.instance;
        timeTaken = timeTaken ?? TimeManager.instance;
        health = health ?? HealthController.instance;
        weapon = weapon ?? WeaponManager.instance;
        playerName = playerName ?? ProfileManager.instance;
        playerAge = playerAge ?? ProfileManager.instance;
        playerGender = playerGender ?? ProfileManager.instance;
        characterName = characterName ?? ProfileManager.instance;
        coins = coins ?? CoinManager.instance;
        sceneCount = sceneCount ?? DifficultyManager.instance;
        shockwaves = shockwaves ?? PlayerShockwave.instance;
    }

}
