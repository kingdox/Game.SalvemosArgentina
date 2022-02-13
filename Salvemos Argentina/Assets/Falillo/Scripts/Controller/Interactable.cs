using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour {
    [SerializeField] private bool canInteract;
    [SerializeField] private bool playerInside;
    [SerializeField] private GameObject messageCanvas;

    private void Start() {
        HideMessage();
    }

    private void ShowMessage() {
        messageCanvas.SetActive(true);
    }

    private void HideMessage() {
        messageCanvas.SetActive(false);
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player") && canInteract) {
            playerInside = true;
            ShowMessage();
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.CompareTag("Player") && canInteract) {
            playerInside = false;
            HideMessage();
        }
    }

    public void Interact() {
        if (canInteract && playerInside) {
            Debug.Log("Interaccion to wapa");
        } else {
            Debug.Log("El jugador se encuentra fuera de rango");
        }
    }
}
