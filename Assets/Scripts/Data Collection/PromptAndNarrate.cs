using LLMUnity;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PromptAndNarrate : MonoBehaviour
{
    public LLMNarrative llmNarrative;
    public PromptAndDisplay prompt;
    public Text AIText;
    public string textTag = "NarrativeText";

    private void Awake() 
    {
        if (llmNarrative == null)
        {
            llmNarrative ??= GetComponentInChildren<LLMNarrative>();
            llmNarrative = FindObjectOfType<LLMNarrative>();
        }   

        GameObject foundTextObject = GameObject.FindWithTag(textTag);
            if (foundTextObject != null)
            {
                AIText = foundTextObject.GetComponent<Text>();
            }
            else
            {
                Debug.LogWarning($"Canvas with the tag '{textTag}' not found in the scene!");
            }
    }
    
    void Start()
    {
        StartCoroutine(InitializeAfterDelay1());
    }

    IEnumerator InitializeAfterDelay1()
    {
        //waits 0.1 seconds until it asks the LLM to write a narrative
        yield return new WaitForSeconds(0.01f);

        ////for meta prompt
        //Debug.Log("This is the narrative prompt: " + prompt.GetMetaPrompt());

        ////for zero shot prompt
        Debug.Log("This is the narrative prompt: " + prompt.GetZeroShotPrompt());

        ////meta prompt
        //string promptString = prompt.GetMetaPrompt();

        ////zero shot prompt
        string promptString = prompt.GetZeroShotPrompt();

        AIText.text = "Narrative is loading...";
        _ = llmNarrative.Chat(promptString, SetAIText);
    }

    void Update()
    {
        
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
