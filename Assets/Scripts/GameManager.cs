using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Button spinButton;
    [SerializeField] private Reel[] reels; // assign all reel objects here

    private void Start()
    {
        spinButton.onClick.AddListener(OnSpinButtonPressed);
    }

    private void OnSpinButtonPressed()
    {
        Debug.Log("Spin button pressed!");
        StartCoroutine(SpinAllReels());
    }

    private IEnumerator SpinAllReels()
    {
        foreach (Reel reel in reels)
        {
            reel.Spin();
        }

        // Wait for all reels to finish spinning
        bool spinning = true;
        while (spinning)
        {
            spinning = false;
            foreach (Reel reel in reels)
            {
                if (reel.gameObject.activeInHierarchy) // just a check
                    spinning |= reel != null && reel.enabled; // check if spinning
            }
            yield return null;
        }

        CheckWin();
    }

    private void CheckWin()
    {
        if (reels.Length < 2) return;

        int firstSymbol = reels[0].currentSymbolIndex;
        bool allMatch = true;

        foreach (Reel reel in reels)
        {
            if (reel.currentSymbolIndex != firstSymbol)
            {
                allMatch = false;
                break;
            }
        }

        if (allMatch)
            Debug.Log("?? You Win!");
        else
            Debug.Log("Try Again!");
    }
}
