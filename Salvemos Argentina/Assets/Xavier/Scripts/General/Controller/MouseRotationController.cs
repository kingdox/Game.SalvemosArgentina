using System;
using UnityEngine;

[Serializable]
[RequireComponent(typeof(Camera))]
public class MouseRotationController
{
    private Vector3 mousePosition = default;
    private Vector3 posInScreen = default;
    private Vector3 direction = default;

    public void Rotate(Transform target, Camera cam){

        mousePosition = Input.mousePosition;
        posInScreen = cam.WorldToScreenPoint(target.position);
        direction =  mousePosition - posInScreen;
        target.rotation = Quaternion.AngleAxis(
            Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg,
            Vector3.up
        );
        
    }
}

