using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class LevelPreview : MonoBehaviour
{
    public LevelData levelData;
    public Transform wordContainer;
    public GameObject wordButtonPrefab;
    public Animator animator;
    public Image feedbackImage;
    public Sprite correctSign;
    public Sprite wrongSign;
    public GameObject levelClearedCanvas;
    public GameObject endGameCanvas;

    private int correctWordCount = 0;
    private int attemptsRemaining = 3;
    private bool isLevelCleared = false;

    void Start()
    {
        if (levelData == null || wordContainer == null || wordButtonPrefab == null || feedbackImage == null)
        {
            Debug.LogError("Ensure all references are assigned in the inspector!");
            return;
        }

        if (levelData.animatorController != null && animator != null)
        {
            // Assign the RuntimeAnimatorController from the ScriptableObject
            animator.runtimeAnimatorController = levelData.animatorController;
        }
        else
        {
            Debug.LogError("Animator or AnimatorController is missing!");
        }

        foreach (var word in levelData.words)
        {
            GameObject button = Instantiate(wordButtonPrefab, wordContainer);
            button.GetComponentInChildren<TextMeshProUGUI>().text = word;
            button.GetComponent<Button>().onClick.AddListener(() => OnWordSelected(word));
        }

        feedbackImage.gameObject.SetActive(false);
    }

    void OnWordSelected(string selectedWord)
    {
        if (attemptsRemaining <= 0)
        {
            EndGame();
            return;
        }

        if (System.Array.Exists(levelData.correctWords, word => word == selectedWord))
        {
            correctWordCount++;
            Debug.Log("Correct word selected!");
            ShowFeedback(true);

            if (correctWordCount == levelData.correctWords.Length)
            {
                StartCoroutine(ClearLevel());
            }
        }
        else
        {
            attemptsRemaining--;
            Debug.Log("Incorrect word selected. Attempts remaining: " + attemptsRemaining);
            ShowFeedback(false);

            if (attemptsRemaining == 0)
            {
                EndGame();
            }
        }
    }

    public void ShowFeedback(bool isCorrect)
    {
        feedbackImage.sprite = isCorrect ? correctSign : wrongSign;
        feedbackImage.gameObject.SetActive(true);
        StartCoroutine(HideFeedbackAfterDelay());
    }

    IEnumerator HideFeedbackAfterDelay()
    {
        yield return new WaitForSeconds(2f);
        feedbackImage.gameObject.SetActive(false);
    }

    IEnumerator ClearLevel()
    {
        // Trigger the "GameEnded" animation
        animator.SetBool("GameEnded", true);

        // Wait for the animation to play
        yield return new WaitForSeconds(5f);

        levelClearedCanvas.SetActive(true);
    }

    void EndGame()
    {
        StartCoroutine(ShowEndGameCanvas());
    }

    IEnumerator ShowEndGameCanvas()
    {
        yield return new WaitForSeconds(5f);
        endGameCanvas.SetActive(true);
    }
}