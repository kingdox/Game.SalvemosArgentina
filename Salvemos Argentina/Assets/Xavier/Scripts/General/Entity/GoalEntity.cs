#region Access
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XavHelpTo;
using XavHelpTo.Get;
# endregion

public class GoalEntity : ComponentBase
{
    #region Variable

    [Header("Stats")]
    [SerializeField] private ValueController<bool> ctrl_isPlayerGoal;

    [Header("Features")]
    [Space]
    [SerializeField] private ContactTypeController<BallEntity> ctrl_contact_ball;

    public Action<bool> OnEnterGoal;
    #endregion
    #region Events
    private void OnCollisionEnter(Collision collision){
        Collider _collider = collision.collider;
        ctrl_contact_ball.Check(in _collider, OnCollisionWithBall);
    }
    #endregion
    #region Methods
    protected override void Suscribe(bool condition)
    {
        //$"{condition}".Print("green");
    }

    private void OnCollisionWithBall(BallEntity ballEntity)
    {
        //if (ctrl_isPlayerGoal.Value) "Gol!!!!".Print(); 
        //ballEntity.transform.position
        OnEnterGoal?.Invoke(ctrl_isPlayerGoal.Value);
    }
    #endregion
}
