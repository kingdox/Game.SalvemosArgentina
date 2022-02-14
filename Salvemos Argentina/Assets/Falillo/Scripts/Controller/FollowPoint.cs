using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPoint : MonoBehaviour
{
    public Transform target;
    public float speed;
    public bool follow;

    private void Update() {
        if (follow) {
            Follow();
        }
    }

    private void Follow() {
        transform.position = Vector3.Lerp(transform.position,target.position,speed);
    }
}
