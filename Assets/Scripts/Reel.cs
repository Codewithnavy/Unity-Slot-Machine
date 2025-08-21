using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Reel : MonoBehaviour
{
    public Image reelImage; // UI Image to show symbols
    public Sprite[] symbols; // assign your slot symbols in Inspector

    [HideInInspector] public int currentSymbolIndex;

    private bool spinning = false;

    // Start spinning
    public void Spin()
    {
        spinning = true;
        StartCoroutine(SpinReel());
        
    {
        Debug.Log("Spin button clicked and function was called!");
        // ... rest of your spin logic
    }
}

    // Coroutine to simulate spinning
    private IEnumerator SpinReel()
    {
        float duration = Random.Range(1.0f, 2.0f); // random spin time
        float elapsed = 0f;

        while (elapsed < duration)
        {
            int index = Random.Range(0, symbols.Length);
            reelImage.sprite = symbols[index];
            currentSymbolIndex = index;

            elapsed += 0.1f; // wait time for next symbol
            yield return new WaitForSeconds(0.1f);
        }

        spinning = false;
    }

    // Stop reel immediately
    public void Stop()
    {
        spinning = false;
    }
}
