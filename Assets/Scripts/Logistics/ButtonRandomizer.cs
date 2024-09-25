using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonRandomizer : MonoBehaviour
{
    public static ButtonRandomizer instance;

    public Button[] buttons; // Array to hold references to your buttons
    public int buttonsToShow = 2; // Number of buttons to show (set through Inspector or dynamically)
    public bool buttonRandomised = false;

    private void Awake()
    {
        instance = this;
    }

    private void OnEnable()
    {
        // Reset the flag when the object becomes active
        buttonRandomised = false;
    }

    private void Start()
    {
        // Randomize buttons only if they haven't been randomized yet
        if (!buttonRandomised)
        {
            RandomizeButtons();
            buttonRandomised = true;
        }
    }

    private void Update()
    {
        // If the game object is active and the buttons haven't been randomized yet, randomize them
        if (this.gameObject.activeSelf && !buttonRandomised)
        {
            RandomizeAgain(buttonsToShow);
            buttonRandomised = true;
        }
    }

    public void SetButtonsToShow(int number)
    {
        // Ensure the number of buttons to show is within a valid range
        buttonsToShow = Mathf.Clamp(number, 1, buttons.Length);
    }

    void RandomizeButtons()
    {
        // Hide all buttons initially
        foreach (Button button in buttons)
        {
            button.gameObject.SetActive(false);
        }

        // Randomly select 'buttonsToShow' buttons to display
        List<int> indices = new List<int>();
        for (int i = 0; i < buttons.Length; i++)
        {
            indices.Add(i);
        }

        for (int i = 0; i < buttonsToShow; i++)
        {
            int randomIndex = Random.Range(0, indices.Count);
            buttons[indices[randomIndex]].gameObject.SetActive(true);
            indices.RemoveAt(randomIndex);
        }
    }

    public void RandomizeAgain(int newButtonsToShow)
    {
        SetButtonsToShow(newButtonsToShow);
        RandomizeButtons();
    }
}
