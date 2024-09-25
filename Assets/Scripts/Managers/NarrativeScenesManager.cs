using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NarrativeScenesManager : MonoBehaviour
{
    public Text endOfScenePromptText;
    public Text promptText;
    public PromptAndDisplay prompt;
    
    // Start is called before the first frame update
    void Start()
    {
        ReloadPrompts();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ReloadPrompts()
    {
        prompt = FindObjectOfType<PromptAndDisplay>();
        if (prompt!= null)
        {
            ////meta prompt 
          //promptText = prompt.metaPromptText;
          //prompt.UpdateMetaPromptText(string.Empty);
            
            ////zero shot prompt 
         promptText = prompt.zeroShotPromptText;
         prompt.UpdateZeroShotPromptText(string.Empty);
        }
        else
        {
            Debug.LogError("PromptAndDisplay instance not found in the new scene.");
        }
    }
}
