#region Acccess
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XavHelpTo;
using XavHelpTo.Get;
using XavHelpTo.Change;
using XavHelpTo.Set;
# endregion

public class BlockerEntity : MonoBehaviour
{
    #region Variables
    [Header("Attributes")]
    [Space]
    [SerializeField] private Transform tr_ball;
    [SerializeField] private float speed;
    [SerializeField] private Vector2 speedRange;

    [Header("Features")]
    [Space]
    [SerializeField] private TimerController ctrl_timer_changeSpeed;
    #endregion
    #region
    private void Update(){
        if (Time.timeScale.Equals(0)) return;
        Move();

        if (ctrl_timer_changeSpeed.Timer()) ChangeSpeed();
    }
    #endregion
    #region Methods
    private void Move(){

       float ballPosX = tr_ball.position.x;
        Vector3 pos = transform.position;
        transform.position= Vector3.Lerp(
            pos,
            pos.Axis(0, ballPosX),
            speed * Time.deltaTime
        );
    }

    private void ChangeSpeed() => speed = speedRange.Range();
    #endregion

}
