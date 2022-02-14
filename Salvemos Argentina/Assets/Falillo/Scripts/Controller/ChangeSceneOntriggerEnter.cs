using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using XavHelpTo.Change;

public class ChangeSceneOntriggerEnter : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            SceneManager.LoadScene(GameManager.GameScenes.GAME.ToInt());
        }
    }
}
