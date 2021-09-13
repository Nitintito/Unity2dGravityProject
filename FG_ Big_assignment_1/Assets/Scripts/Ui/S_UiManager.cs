using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_UiManager : MonoBehaviour
{
    public static bool levelFaild;
    [SerializeField]GameObject pausMenuCanvas;
    [SerializeField] GameObject loseMenuCanvas;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pausMenuCanvas.active == false)
                pausMenuCanvas.SetActive(true);
            else
                pausMenuCanvas.SetActive(false);
        }

        if (levelFaild)
            loseMenuCanvas.SetActive(true);
        else
            loseMenuCanvas.SetActive(false);

    }
}
