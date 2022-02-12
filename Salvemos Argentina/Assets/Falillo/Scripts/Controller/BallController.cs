using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class BallController {
    //Fuerza con la que el rigidbody ser? lanzado
    [SerializeField] private float bounceForce;
    [SerializeField] private float friction;

    [Header("Requirements")]
    [SerializeField] private Rigidbody rB;
    [SerializeField] private Transform transform;

    /// <summary>
    /// Aplica fuerza hacia el vector contrario de donde ha recibido el disparo
    /// </summary>
    public void ApplyForce(Vector3 shooterPosition) {
        //Con la posici?n del que ha disparado a la bola, calculo el vector hacia donde se deber?a de mover la bola
        Vector3 forzeDirection = transform.position - shooterPosition;
        //Aplico a la velocidad de la bola la direcci?n por la
        rB.velocity = forzeDirection.normalized * bounceForce;
    }

    /// <summary>
    /// resta velocidad al rigidbody dado un valor de reduccion de velocidad
    /// </summary>
    public void ReduceVelocity() {
        if (rB.velocity.magnitude > Vector3.zero.magnitude) {
            rB.velocity = Vector3.Lerp(rB.velocity,Vector3.zero,friction);
        }
    }

}
