using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public LevelData levelData;

    private void Start()
    {
        Debug.Log($"Level Name: {levelData.levelName}");
        Debug.Log("Words: " + string.Join(", ", levelData.words));
    }
}
