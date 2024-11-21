using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public  class Feedback : MonoBehaviour
{
    public Image feedbackImage;
    public Sprite correctSign;
    public Sprite wrongSign;

    private void Start()
    {
        if (feedbackImage == null || correctSign == null || wrongSign == null)
        {
            Debug.LogError("Ensure all Feedback references are assigned in the inspector!");
            return;
        }
    }

    // This method shows feedback for the player's selection
    public void ShowFeedback(bool isCorrect)
    {
        // Set the sprite based on whether the selection was correct or wrong
        feedbackImage.sprite = isCorrect ? correctSign : wrongSign;
        feedbackImage.gameObject.SetActive(true);

        // Hide the image after 1 second
        StartCoroutine(HideFeedbackAfterDelay());
    }

    // Coroutine to hide the feedback image after a delay
    IEnumerator HideFeedbackAfterDelay()
    {
        yield return new WaitForSeconds(1f); // Wait for 1 second
        feedbackImage.gameObject.SetActive(false);
    }
}
