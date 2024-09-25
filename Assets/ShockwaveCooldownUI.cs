using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShockwaveCooldownUI : MonoBehaviour
{
    [SerializeField] private Image cooldownImage;
    [SerializeField] private TextMeshProUGUI cooldownText;
    [SerializeField] private PlayerShockwave playerShockwave;


    //void Awake()
    //{
    //    this.DontDestroyOnLoad();
    //}

    void Update()
    {
        float cooldownRemaining = playerShockwave.GetTimeUntilNextShockwave();
        cooldownImage.fillAmount = Mathf.Clamp01(1f - cooldownRemaining / playerShockwave.GetTimeBetweenShockwave());

        if (cooldownRemaining > 0)
        {
            cooldownText.text = cooldownRemaining.ToString("F1");
            cooldownImage.color = new Color(1f, 1f, 1f, 0.5f); 
        }
        else
        {
            cooldownText.text = "";
            cooldownImage.color = Color.white; 
        }
    }
}
