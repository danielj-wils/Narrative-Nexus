using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public List<Button> allButtons;
    public List<string> sceneNames;

    private List<Button> activeButtons = new List<Button>();

    void Start()
    {
        if (allButtons.Count != sceneNames.Count)
        {
            Debug.LogError("Number of buttons and scene names must match.");
            return;
        }

        RandomizeButtons();
    }

    void RandomizeButtons()
    {
        // Deactivate all buttons initially
        foreach (Button button in allButtons)
        {
            button.gameObject.SetActive(false);
        }

        // Randomly select two indices
        List<int> randomIndices = new List<int>();
        while (randomIndices.Count < 2)
        {
            int index = Random.Range(0, allButtons.Count);
            if (!randomIndices.Contains(index))
            {
                randomIndices.Add(index);
            }
        }

        // Activate the selected buttons and assign their onClick events
        foreach (int index in randomIndices)
        {
            Button button = allButtons[index];
            button.gameObject.SetActive(true);
            int sceneIndex = index; // Capture index for closure
            button.onClick.AddListener(() => LoadScene(sceneNames[sceneIndex]));
            activeButtons.Add(button);
        }
    }

    void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}