using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_FulePickUp : MonoBehaviour
{
    [SerializeField] S_Player player;
    S_FuleUi fuleUi;

    private void Awake()
    {
        fuleUi = FindObjectOfType<S_FuleUi>();
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
