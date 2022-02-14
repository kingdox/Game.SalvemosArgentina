using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameInteractable : MonoBehaviour
{
    [SerializeField] private bool canInteract;
    [SerializeField] private bool playerInside;
    [SerializeField] private GameObject messageCanvas;

    public EndAnimation endAnimation;

    private void Start() {
        HideMessage();
    }

    private void ShowMessage() {
        messageCanvas.SetActive(true);
    }

    private void HideMessage() {
        messageCanvas.SetActive(false);
    }

    private void Update() {
        if (canInteract) {
            if (Input.GetKey(KeyCode.F)) {
                Debug.Log("Interactua");
                Interact();
            }
        }
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
        if (playerInside) {
            canInteract = false;
            HideMessage();
            endAnimation.StartEndAnimation();
            return;
        } else {
            Debug.Log("El player está fuera");
        }
    }
}
