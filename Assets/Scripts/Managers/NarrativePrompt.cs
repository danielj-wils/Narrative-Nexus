using UnityEngine;
using LLMUnity;
using UnityEngine.UI;
using System.Collections;

namespace LLMUnitySamples
{
    public class NarrativePrompt : MonoBehaviour
    {
        public LLMNarrative llmNarrative;
        public Text AIText;
        
        public ProfileManager playerName;
        public ProfileManager playerAge;
        public ProfileManager playerGender;
        public ProfileManager characterName;

        public readonly int maxWords = 250;
        public readonly int maxTokens = 300;

        private string startPrompt;

        private void Awake() 
        {
            if (llmNarrative == null)
            {
                llmNarrative = FindObjectOfType<LLMNarrative>();
            }   
        }
        
        void Start()
        {
            //if (playerName = null)
            //{
            //    playerName = FindObjectOfType<ProfileManager>();
            //}
            StartCoroutine(InitializeAfterDelay());
            
        }

        IEnumerator InitializeAfterDelay()
        {
            yield return new WaitForSeconds(0.5f); 
            //FindDependencies();

            GenerateStartPrompt();
            Debug.Log("This is the introduction prompt: " + startPrompt);  
            
            AIText.text = "Narrative is loading...";
            _ = llmNarrative.Chat(startPrompt, SetAIText);
            Debug.Log("Narrative is being generated.");  
            
        }

        void GenerateStartPrompt()
        {
            startPrompt = $"You must create a diverse, descriptive and interesting introductory third-person narrative for a top-down shooter player.\n" + 
                              $"The game involves the player navigating through a series of rooms/scenes killing enemies with the option to collect coins to get increase their score. Once all the enemies in a room has been killed, the player has the choice of which room/scene to travel to next.\n" +
                                $"Human Audience Information (This describes the profile of the real player and not the game player): \n" +
                                $"**You should not need to explicitly use this player profile information - instead tailor the tone to this attribute**\n" +
                                $"\tAge: {playerAge.GetPlayerAge()}\n" +
                                $"\tName: {playerName.GetPlayerName()}\n" +  
                                $"\tGender: {playerGender.GetPlayerGender()}\n" +
                                $"Game information you should know and can use within the narrative:\n" +
                                $"Game Player Character Name: {characterName.GetPlayerCharacterName()}\n" +
                                $"The player is currently at the very start of his journey, in a black dark empty room\n" +
                                $"\tScenes/rooms which the player COULD potentially visit but this is random, not guaranteed and reliant on player choice and decision path: Dungeon, Lava, Meadow, Underwater, Desert, Forest, City, Mountain and Snow\n" +  
                                $"\tWeapons available: gun and smokebombs\n" +
                                $"\tEnemies: men with guns\n" +
                                $"(The following details and instructions should be followed) \n" +
                                $"\tEnsure the produced narrative does not stop in the middle of a word or sentence at the max word limit of {maxWords} words nor the max token limit of {maxTokens} tokens\n" +
                                $"\tThis does not need a title\n" +
                                $"\tAgain, do not explicitly use the players age\n" +
                                $"\tDo not confuse the real game player profile information with the game player information\n" +
                                $"\tEnsure the narrative is creative, personal in accordance with the player character name and sets the scene for the game. It should understand that the game is a top-down shooter and reflect this in its words. Its tone and phrases should be appropriate according to the player profile information provided.";
        }

        public void SetAIText(string text)
        {
            AIText.text = text;
        }

        public void CancelRequests()
        {
            llmNarrative.CancelRequests();
        }

        bool onValidateWarning = true;
        void OnValidate()
        {
            if (onValidateWarning && llmNarrative.llm.model == "")
            {
                Debug.LogWarning($"Please select a model in the {llmNarrative.llm.gameObject.name} GameObject!");
                onValidateWarning = false;
            }
        }
    }
}
