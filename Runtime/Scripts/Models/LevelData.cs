using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewLevelData", menuName = "Level/Level Data")]
public class LevelData : ScriptableObject
{
    public string levelName;
    public string[] words;
    public string[] correctWords;
    public RuntimeAnimatorController animatorController;
}
