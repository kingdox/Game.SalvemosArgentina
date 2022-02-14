using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameOntriggerEnter : MonoBehaviour
{
    public GameObject endGameUI;

    private void Start() {
        endGameUI.SetActive(false);
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            endGameUI.SetActive(true);
        }
    }
}
