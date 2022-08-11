using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_FulePickUp : MonoBehaviour
{
    S_Player player;
    S_FuleUi fuleUi;

    private void Awake()
    {
        fuleUi = FindObjectOfType<S_FuleUi>();
        player = FindObjectOfType<S_Player>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            player.currentFule = player.startFule;
            fuleUi.SetFule(player.currentFule);
            Destroy(gameObject);
        }
    }
}
