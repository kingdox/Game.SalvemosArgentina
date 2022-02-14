using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour {
    bool dialogueDone = false;

    public string[] messages;
    private int messagesCounter;
    private int currentMessage;
    public GameObject dialogueObject;
    public Text messageText;

    private void Start() {
        dialogueObject.SetActive(false);
    }

    public void StartDialogue() {
        Debug.Log("Comienza el dialogo");
        messagesCounter = messages.Length;
        currentMessage = 0;
        messageText.text = messages[0];
        dialogueObject.SetActive(true);
        currentMessage++;
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.F)) {
            NextMessage();
        }
    }

    [ContextMenu("SiguienteMensaje")]
    public void NextMessage() {
        if (currentMessage < messagesCounter) {
            messageText.text = messages[currentMessage];
            currentMessage++;
        } else {
            FinishDialogue();
        }
    }

    public void FinishDialogue() {
        dialogueObject.SetActive(false);
        dialogueDone = true;
    }
}
