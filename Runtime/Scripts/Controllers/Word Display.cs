using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Still needed for Button
using TMPro;

public class WordDisplay : MonoBehaviour
{
    public LevelData levelData; // Reference to LevelData ScriptableObject
    public Transform wordContainer; // Reference to the container for buttons
    public GameObject wordButtonPrefab; // Reference to the button prefab

    void Start()
    {
        if (levelData == null)
        {
            Debug.LogError("LevelData is not assigned!");
            return;
        }

        if (wordButtonPrefab == null)
        {
            Debug.LogError("WordButtonPrefab is not assigned!");
            return;
        }

        if (wordContainer == null)
        {
            Debug.LogError("WordContainer is not assigned!");
            return;
        }

        foreach (var word in levelData.words)
        {
            Debug.Log($"Creating button for word: {word}");
            GameObject button = Instantiate(wordButtonPrefab, wordContainer);
            var textComponent = button.GetComponentInChildren<TextMeshProUGUI>();

            if (textComponent != null)
            {
                textComponent.text = word;
                Debug.Log($"Set text: {word}");
            }
            else
            {
                Debug.LogError("TextMeshProUGUI component not found on the prefab!");
            }
        }
    }
}
