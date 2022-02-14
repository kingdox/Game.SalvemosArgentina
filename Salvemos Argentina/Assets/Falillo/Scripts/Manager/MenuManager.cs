using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using XavHelpTo.Change;

public class MenuManager : MonoBehaviour
{
    /// <summary>
    /// Método que carga la escena de juego 1
    /// </summary>
    public void LoadScene() {
        SceneManager.LoadScene(GameManager.GameScenes.INTRO.ToInt());
    }

    /// <summary>
    /// Método para salir del juego
    /// </summary>
    public void ExitGame() {
        Application.Quit();
    }
}
