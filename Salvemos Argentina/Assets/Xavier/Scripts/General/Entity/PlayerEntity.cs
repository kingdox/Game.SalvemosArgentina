#region
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using XavHelpTo;
using XavHelpTo.Get;
# endregion

public class PlayerEntity : ComponentBase
{
    #region Variable
    [Header("Stats")]
    [Space]
    [SerializeField] private ValueController<Camera> ctrl_value_camera;
    [SerializeField] private ValueController<float> ctrl_value_speed;
    [SerializeField] private ValueController<int> ctrl_value_ammo;
    [SerializeField] private ValueController<int> ctrl_value_ammoMax;
    [SerializeField] private ValueController<bool> ctrl_value_canShoot;

    [Header("Behaviour")]
    [Space]
    [SerializeField] private TimerController ctrl_timer_shot;

    [Header("Features")]
    [Space]
    [SerializeField] private CommandsController ctrl_commands = default;
    [SerializeField] private PhysicController ctrl_physic = default;
    [SerializeField] private MouseRotationController ctrl_mouse_rotation = default;
    [SerializeField] private RayCastController ctrl_raycast = default;

    #endregion
    #region Event
    private void Awake()
    {
        
    }
    private void Update()
    {
        ctrl_commands.CheckUpdate();
        ctrl_mouse_rotation.Rotate(transform, ctrl_value_camera.Value);
        if (ctrl_timer_shot.Timer()) ctrl_value_canShoot.Value = true;
    }
    private void FixedUpdate()
    {
        ctrl_commands.CheckFixedUpdate();
    }
    #endregion
    #region Methods
    protected override void Suscribe(bool condition)
    {
        condition.Print();
    }
    public void Move_Up() => ctrl_physic.Move(ctrl_value_speed.Value, PhysicController.Direction.Z);
    public void Move_Down() => ctrl_physic.Move(-ctrl_value_speed.Value, PhysicController.Direction.Z);
    public void Move_Right() => ctrl_physic.Move(ctrl_value_speed.Value, PhysicController.Direction.X);
    public void Move_Left() => ctrl_physic.Move(-ctrl_value_speed.Value, PhysicController.Direction.X);

    public void Shoot(){
        if (ctrl_value_canShoot.Value)
        {
            ctrl_value_ammo.Value--;
            ctrl_value_canShoot.Value = false;
            Transform tr_ball =  ctrl_raycast.CastRay();
            tr_ball.Component(out BallEntity ballEntity);
            ballEntity.ApplyForce(transform.forward);
        }
        else
        {
            "NO Shoot".Print("red");
        }
    }

    public void GetAmmo(ValueController<int> _ammo) => ctrl_value_ammo.Value = _ammo.Value.Max(ctrl_value_ammoMax.Value);
    #endregion
}
