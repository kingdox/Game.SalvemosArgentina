using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    /// <summary>
    /// M�todo que carga la escena de juego 1
    /// </summary>
    public void LoadScene(string sceneName) {
        SceneManager.LoadScene(sceneName);
    }

    /// <summary>
    /// M�todo para salir del juego
    /// </summary>
    public void ExitGame() {
        Application.Quit();
    }
}
