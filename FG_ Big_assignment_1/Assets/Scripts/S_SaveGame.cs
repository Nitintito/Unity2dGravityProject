using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class S_SaveGame : MonoBehaviour
{
    private void Awake()
    {
        if (PlayerPrefs.GetInt("Unlocked Levels") != 0)
        {
            S_LevelSelectMenu.unlockedLevels = PlayerPrefs.GetInt("Unlocked Levels");
        }
    }
    private void OnApplicationQuit()
    {
        PlayerPrefs.SetInt("Unlocked Levels", S_LevelSelectMenu.unlockedLevels);
        S_LevelSelectMenu.unlockedLevels = PlayerPrefs.GetInt("Unlocked Levels");
    }
}
