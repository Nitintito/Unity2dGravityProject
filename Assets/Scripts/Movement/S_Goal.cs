using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


//[RequireComponent(typeof(Collider2D))]
public class S_Goal : MonoBehaviour
{
    [SerializeField]GameObject winUiCanvas;
    public static bool win;

    private void Awake()
    {
        win = false;
    }

    void Update()
    {
        Debug.Log("Count " + SceneManager.GetActiveScene().buildIndex);
        Debug.Log("Unlocket " + S_LevelSelectMenu.unlockedLevels);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            win = true;
            winUiCanvas.SetActive(true);

            if (SceneManager.GetActiveScene().buildIndex == S_LevelSelectMenu.unlockedLevels)
            {
                S_LevelSelectMenu.unlockedLevels += 1;
                PlayerPrefs.SetInt("Unlocked Levels", S_LevelSelectMenu.unlockedLevels);
            }
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

