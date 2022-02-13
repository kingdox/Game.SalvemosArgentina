using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallEntity : ComponentBase
{
    #region
    [SerializeField] private ValueController<Rigidbody> ctrl_body;
    [SerializeField] private BallController ctrl_ball;
    #endregion
    #region
    private void Start(){
        
    }
    private void FixedUpdate()
    {
        ctrl_ball.ReduceVelocity();
    }
    #endregion
    #region Methods
    protected override void Suscribe(bool condition)
    {
    }
    public void ApplyForce(Vector3 shooterPosition) => ctrl_ball.ApplyForce(shooterPosition);
    public void ResetForce() => ctrl_body.Value.velocity = Vector3.zero;
    #endregion
}
