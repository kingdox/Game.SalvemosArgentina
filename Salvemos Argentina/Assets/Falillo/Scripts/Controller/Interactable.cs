using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XavHelpTo;

public class Interactable : MonoBehaviour {
    [SerializeField] private bool canInteract;
    [SerializeField] private bool playerInside;
    [SerializeField] private GameObject messageCanvas;

    public Dialogue dialogue;

    public bool activateFollowingAfterInteractXD;
    public FollowPoint followPoint;

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
            dialogue.gameObject.SetActive(true);
            dialogue.StartDialogue();
            if (activateFollowingAfterInteractXD) {
                followPoint.Component(out Animator a).enabled = false;
                followPoint.follow = true;
            }
            return;
        } else {
            Debug.Log("El player está fuera");
        }
    }
}
