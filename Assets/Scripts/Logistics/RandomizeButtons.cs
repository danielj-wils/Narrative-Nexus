using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RandomizeButtons : MonoBehaviour
{
    public List<Button> buttons;
    public List<string> sceneNames;
    public int buttonsToShow = 2; 

    void Start()
    {
        //buttons = GetComponentInChildren<ButtonPanel>();

        if (buttons.Count != sceneNames.Count)
        {
            Debug.LogError("The number of buttons must match the number of scenes.");
            return;
        }

        // Deactivate all buttons initially
        foreach (var button in buttons)
        {
            button.gameObject.SetActive(false);
        }

        // Randomly select and activate 'buttonsToShow' buttons
        List<int> selectedIndices = GetRandomIndices(buttons.Count, buttonsToShow);

        foreach (int index in selectedIndices)
        {
            buttons[index].gameObject.SetActive(true);
            //int sceneIndex = index; // Capture index to avoid closure issue in loop
            //buttons[index].onClick.AddListener(() => LoadScene(sceneNames[sceneIndex]));
        }

        // Ensure selected buttons are organized next to each other
        OrganizeButtons(selectedIndices);
    }

    void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    List<int> GetRandomIndices(int count, int numberOfIndices)
    {
        List<int> indices = new List<int>();
        while (indices.Count < numberOfIndices)
        {
            int randomIndex = Random.Range(0, count);
            if (!indices.Contains(randomIndex))
            {
                indices.Add(randomIndex);
            }
        }
        return indices;
    }

    void OrganizeButtons(List<int> selectedIndices)
    {
        // Assuming all buttons are children of a parent GameObject with a LayoutGroup
        foreach (Transform child in buttons[0].transform.parent)
        {
            child.SetSiblingIndex(buttons.Count); // Move all children to the end
        }

        // Move selected buttons to the beginning of the LayoutGroup
        for (int i = 0; i < selectedIndices.Count; i++)
        {
            buttons[selectedIndices[i]].transform.SetSiblingIndex(i);
        }
    }
}
