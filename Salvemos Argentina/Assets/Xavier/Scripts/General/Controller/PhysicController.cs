using System;
using UnityEngine;
using XavHelpTo;
[Serializable]
public class PhysicController 
{
    public enum Direction
    {
        X,
        Y,
        Z
    }

    [Header("Requirements")]
    [Space]
    [SerializeField] private Rigidbody body = default;

    [Header("Behaviour")]
    [Space]
    [SerializeField] private ForceMode forceMode = default;


    //Test
    //public PhysicController(
    //    Rigidbody body
    //){
    //    this.body = body;

    //}

    public void Move(float qty, Direction direction){
        //$"Move in {direction} with {qty}".Print();
        switch (direction)
        {
            case Direction.X:
                body.AddForce(Vector3.right * qty, forceMode);
                break;
            case Direction.Y:
                body.AddForce(Vector3.up * qty, forceMode);
                break;
            case Direction.Z:
                body.AddForce(Vector3.forward * qty, forceMode);
                break;
        }
    }

    public void MoveInDirection(float qty, Vector3 direction)
    {
        body.AddForce(qty * direction, forceMode);
    }
}
