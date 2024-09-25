using System.Collections;
using UnityEngine;

public class SpriteFlash : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    private void Awake() 
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    public IEnumerator FlashCoroutine(float flashDuration, Color flashColor, int numberOfFlashes)
    {
        Color startColour = spriteRenderer.color;
        float flashTimePerCycle = flashDuration / (numberOfFlashes * 2);

        for (int i = 0; i < numberOfFlashes; i++)
        {
            // Flash to the flashColor
            spriteRenderer.color = flashColor;
            yield return new WaitForSeconds(flashTimePerCycle);

            // Flash back to the original color
            spriteRenderer.color = startColour;
            yield return new WaitForSeconds(flashTimePerCycle);
        }

        // Reset color to the original after flashing
        spriteRenderer.color = startColour;
    }
}
