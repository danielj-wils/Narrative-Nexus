using System.Collections;
using UnityEngine;

public class SpriteFlashInvincibility : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    private void Awake() 
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    public IEnumerator FlashCoroutine(float flashDuration, Color flashColor, int numberOfFlashes)
    {
        Color startColour = spriteRenderer.color;

        // Time per flash (on + off)
        float flashTime = flashDuration / (numberOfFlashes * 2);
        
        for (int i = 0; i < numberOfFlashes; i++)
        {
            // Flash to the flashColor
            spriteRenderer.color = flashColor;
            yield return new WaitForSeconds(flashTime);
            
            // Flash back to the original color
            spriteRenderer.color = startColour;
            yield return new WaitForSeconds(flashTime);
        }

        // Reset color at the end just to ensure it's back to the original color
        spriteRenderer.color = startColour;
    }
}
