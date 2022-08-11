using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class s_PausMenu : MonoBehaviour
{

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // reload current level
        Debug.Log("Restart");
    }

    public void MainMenu()
    {
        Debug.Log("Main Menu");
        SceneManager.LoadScene(0);
    }
}
