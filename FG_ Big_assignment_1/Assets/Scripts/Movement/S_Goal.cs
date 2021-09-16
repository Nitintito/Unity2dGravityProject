using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[RequireComponent(typeof(Collider2D))]
public class S_Goal : MonoBehaviour
{
    [SerializeField]GameObject winUiCanvas;
    public static bool win;

    private void Awake()
    {
        win = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            win = true;
            winUiCanvas.SetActive(true);
            S_LevelSelectMenu.unlockedLevels += 1;
            Debug.Log("You Win!");
            PlayerPrefs.SetInt("Unlocked Levels", S_LevelSelectMenu.unlockedLevels);
        }
    }

    private void WinUi()
    {
        if (winUiCanvas != null)
        {
            winUiCanvas.SetActive(true);
        }
    }
}

