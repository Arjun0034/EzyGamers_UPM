using UnityEngine;
using System.IO;
using System.Collections;

public class SaveLoadSystem : MonoBehaviour
{
    private string saveFilePath;

    private void Start()
    {
        saveFilePath = Path.Combine(Application.persistentDataPath, "gameSave.json");
        // Start the AutoSave routine when the game starts
        StartCoroutine(AutoSaveRoutine());
    }

    // Save the game state
    public void SaveGame(string levelName, int correctWordCount)
    {
        GameData gameData = new GameData()
        {
            levelName = levelName,
            correctWordCount = correctWordCount
        };

        string json = JsonUtility.ToJson(gameData);
        File.WriteAllText(saveFilePath, json);

        Debug.Log("Game Saved!");
    }

    // Load the game state
    public GameData LoadGame()
    {
        if (File.Exists(saveFilePath))
        {
            string json = File.ReadAllText(saveFilePath);
            GameData loadedData = JsonUtility.FromJson<GameData>(json);
            Debug.Log("Game Loaded: " + loadedData.levelName);
            return loadedData;
        }
        else
        {
            Debug.LogWarning("No saved game found.");
            return null;
        }
    }

    // Auto Save every 60 seconds
    IEnumerator AutoSaveRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(60); // Save every 60 seconds (can be adjusted)
            AutoSaveGame();
        }
    }

    void AutoSaveGame()
    {
        
        string levelName = "Level 1"; 
        int correctWordCount = 5; 
        SaveGame(levelName, correctWordCount);
    }
}

// GameData class to hold the saved data
[System.Serializable]
public class GameData
{
    public string levelName;
    public int correctWordCount;
}
