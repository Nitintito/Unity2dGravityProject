using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[RequireComponent(typeof(Collider2D))]
public class S_Goal : MonoBehaviour
{
    [SerializeField]GameObject winUiCanvas;
    public static bool goal = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("GolfBall"))
        {
            winUiCanvas.SetActive(true);
            Debug.Log("You Win!");
        }
    }

    private void WinUi()
    {
        if (winUiCanvas != null)
        {
            winUiCanvas.gameObject.active = true;
        }
    }
}

