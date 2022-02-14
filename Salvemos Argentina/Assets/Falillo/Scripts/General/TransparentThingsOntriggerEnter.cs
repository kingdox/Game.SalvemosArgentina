using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransparentThingsOntriggerEnter : MonoBehaviour {
    //Lista con todos los objetos que van a transparentarse cuando el jugador entre en el trigger
    public MeshRenderer[] meshesToTransparent;
    //Material base que tienen los objetos
    [SerializeField]
    private Material opaqueMaterial;
    //Material transparente
    [SerializeField]
    private Material transparentMaterial;


    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            ChangeMaterial(transparentMaterial);
        }
    }

    private void OnTriggerStay(Collider other) {
        if (other.CompareTag("Player")) {
            ChangeMaterial(transparentMaterial);
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.CompareTag("Player")) {
            ChangeMaterial(opaqueMaterial);
        }
    }

    /// <summary>
    /// Método que cambia el material de los meshes
    /// </summary>
    /// <param name="materialToShow">Material que cogerán los meshes</param>
    private void ChangeMaterial(Material materialToShow) {
        foreach (MeshRenderer mesh in meshesToTransparent) {
            mesh.material = materialToShow;
        }
    }
}
