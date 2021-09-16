using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class S_SaveGame : MonoBehaviour
{
    private void Awake()
    {
        S_LevelSelectMenu.unlockedLevels = PlayerPrefs.GetInt("Unlocked Levels");
    }
    private void OnApplicationQuit()
    {
        PlayerPrefs.SetInt("Unlocked Levels", S_LevelSelectMenu.unlockedLevels);
        S_LevelSelectMenu.unlockedLevels = PlayerPrefs.GetInt("Unlocked Levels");

    }
}
