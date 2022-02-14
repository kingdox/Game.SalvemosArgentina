using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraChangeOnTriggerEnter : MonoBehaviour
{
    [SerializeField] private Camera cameraMain;
    [SerializeField] private Transform cameraNewPoint;
    [SerializeField] private float speed;
    [SerializeField] private float newCameraScale;

    [SerializeField] private bool active;

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            active = true;
        }
    }

    private void OnTriggerStay(Collider other) {
        if (other.CompareTag("Player")) {
            if (active == false) {
                active = true;
            }
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.CompareTag("Player")) {
            active = false;
        }
    }

    private void Update() {
        if (active) {
            MoveCamera();
            ScaleCamera();
        }
    }

    private void MoveCamera() {
        cameraMain.transform.position = Vector3.Lerp(transform.position,cameraNewPoint.position,speed);
    }
    private void ScaleCamera() {
        cameraMain.orthographicSize = Mathf.Lerp(cameraMain.orthographicSize,newCameraScale,speed);
    }
}
