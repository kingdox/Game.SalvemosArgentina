using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroManager : MonoBehaviour {
    private void HideCursor() {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = false;
    }

    private void Start() {
        HideCursor();
    }
}
