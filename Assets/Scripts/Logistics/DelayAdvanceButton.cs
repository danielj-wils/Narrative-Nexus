using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DelayAdvanceButton : MonoBehaviour
{
    public static DelayAdvanceButton instance;
    public Button button; 
    public TextMeshProUGUI text;
    public float delayTime = 5f; 

    private void Awake() 
    {
        instance = this;
    }
    private void Start()
    {
        text.enabled = false;
        button.enabled = false; // disable the button initially
        StartCoroutine(EnableButton());
    }

    private IEnumerator EnableButton()
    {
        yield return new WaitForSeconds(delayTime);
        button.enabled = true; // enable the button after the delay
        text.enabled= true;
    }
}