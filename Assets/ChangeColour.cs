using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColour : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    private void Awake() 
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    void Start()
    {
        UpdateSpriteColour();
    }

    public void UpdateSpriteColour()
    {
        Color spriteColour = ProfileManager.instance.GetPlayerColour();
        spriteRenderer.color = spriteColour;
    }

    // Update is called once per frame
    void Update()
    {
        // Optional: To update the colour dynamically
        // UpdateSpriteColour();
    }
}
