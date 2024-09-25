using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InputFieldScript : MonoBehaviour
{
    public InputField inputFieldName;
    public InputField inputFieldAge;
    public InputField inputFieldGender;
    public InputField inputFieldCharacterName;
    public TMP_Dropdown dropdownPlayerColour;


    private void Start()
    {
        inputFieldName.onEndEdit.AddListener(OnInputFieldName);
        inputFieldAge.onEndEdit.AddListener(OnInputFieldAge);
        inputFieldGender.onEndEdit.AddListener(OnInputFieldGender);
        inputFieldCharacterName.onEndEdit.AddListener(OnInputFieldCharacterName);
        dropdownPlayerColour.onValueChanged.AddListener(OnDropdownPlayerColour);

        SetDefaultDropdownValue();
    }

    private void SetDefaultDropdownValue()
    {
        int defaultIndex = dropdownPlayerColour.value;

        // Assign the default color based on the dropdown's default value
        OnDropdownPlayerColour(defaultIndex);
    }

    private void OnInputFieldName(string name)
    {
        ProfileManager profile = ProfileManager.GetInstance();
        profile.playerName = name;
    }

    private void OnInputFieldAge(string age)
    {
        ProfileManager profile = ProfileManager.GetInstance();
        profile.playerAge = age;
    }

    private void OnInputFieldGender(string gender)
    {
        ProfileManager profile = ProfileManager.GetInstance();
        profile.playerGender = gender;
    }

    private void OnInputFieldCharacterName(string characterName)
    {
        ProfileManager profile = ProfileManager.GetInstance();
        profile.characterName = characterName;
    }

    private void OnDropdownPlayerColour(int index)
    {
        ProfileManager profile = ProfileManager.GetInstance();

        // Map dropdown index to a color (example mapping)
        Color selectedColor = Color.white;
        switch (index)
        {
            case 0: selectedColor = Color.white; break;
            case 1: selectedColor = Color.red; break;
            case 2: selectedColor = Color.blue; break;
            case 3: selectedColor = Color.green; break;
            case 4: selectedColor = Color.yellow; break;
            // Add more cases if you have more color options
        }

        profile.playerColour = selectedColor;
        //profile.SetPlayerColour(selectedColor); 
    }
}