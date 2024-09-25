using UnityEngine;

public class ProfileManager : MonoBehaviour
{
    [SerializeField] public string playerName = ""; //{ get; set; }
    [SerializeField] public string playerAge = ""; //{ get; set; }
    [SerializeField] public string playerGender = ""; //{ get; set; }
    [SerializeField] public string characterName = ""; //{ get; set; }
    [SerializeField] public Color playerColour = Color.white;

    public static ProfileManager instance;

    private void Awake()
    {
        playerName = "Dan";
        playerAge = "22";
        playerGender = "Male";
        characterName = "Nexus"; 
        playerColour = Color.white;
        
        if (instance == null)
        {
            instance = this;
            //DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public static ProfileManager GetInstance()
    {
        return instance;
    }

    public string GetPlayerName()
    {
        return ProfileManager.GetInstance().playerName;
    }

    public string GetPlayerAge()
    {
        return ProfileManager.GetInstance().playerAge;
    }

    public string GetPlayerGender()
    {
        return ProfileManager.GetInstance().playerGender;
    }
    
    public string GetPlayerCharacterName()
    {
        return ProfileManager.GetInstance().characterName;
    }
    
    public Color GetPlayerColour()
    {
         return ProfileManager.GetInstance().playerColour;
    }
}