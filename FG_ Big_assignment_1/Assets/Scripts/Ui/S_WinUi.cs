using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class S_WinUi : MonoBehaviour
{
    int nextSceneIndex;


    private void Awake()
    {
        nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
    }

    public void Replay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // reload current level
        Debug.Log("Replay");
    }

    public void NextLevel()
    {
        if (SceneManager.sceneCountInBuildSettings > nextSceneIndex) // loads next level if there is one
        {
            SceneManager.LoadScene(nextSceneIndex);
            Debug.Log("Next Level");
        }
    }

    public void MainMenu()
    {
        Debug.Log("Main Menu");
        SceneManager.LoadScene(0);
    }

}
