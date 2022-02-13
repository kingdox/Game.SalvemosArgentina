#region
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using XavHelpTo;
using XavHelpTo.Get;
using XavHelpTo.Change;
using XavHelpTo.Set;
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
    [SerializeField] private ValueController<Transform> ctrl_value_ui_parent_bullets;
    [SerializeField] private ValueController<GameObject> ctrl_obj_mira;
    [SerializeField] private ValueController<ParticleSystem> ctrl_particle_shot;

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
    private void Start()
    {
        RefreshUiBullets();
    }
    private void Update(){
        if (Time.timeScale.Equals(0)) return;

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
        //condition.Print();
    }
    public void Move_Up() => ctrl_physic.Move(ctrl_value_speed.Value, PhysicController.Direction.Z);
    public void Move_Down() => ctrl_physic.Move(-ctrl_value_speed.Value, PhysicController.Direction.Z);
    public void Move_Right() => ctrl_physic.Move(ctrl_value_speed.Value, PhysicController.Direction.X);
    public void Move_Left() => ctrl_physic.Move(-ctrl_value_speed.Value, PhysicController.Direction.X);

    public void Shoot(){

        if (ctrl_value_canShoot.Value)
        {
            ctrl_value_ammo.Value = (ctrl_value_ammo.Value - 1).Min(0);
            bool isWithoutBullets = ctrl_value_ammo.Value.Equals(0);
            RefreshUiBullets();

            //Tiene balas?
            if (!isWithoutBullets)
            {
                ctrl_particle_shot.Value.Play();
                AudioSystem.PlaySound(GeneralSounds.SHOT);
                ctrl_value_canShoot.Value = false;
                Transform tr_ball =  ctrl_raycast.CastRay();

                //Si encuentra la pelota
                if (tr_ball){
                    tr_ball.Component(out BallEntity ballEntity);
                    ballEntity.ApplyForce(transform.position);
                    AudioSystem.PlaySound(GeneralSounds.SHOT_BALL);
                }
            }

        }
        else
        {
            AudioSystem.PlaySound(GeneralSounds.SHOT_NO_BULLETS);
        }
    }

    public void GetAmmo(ValueController<int> _ammo)
    {
        ctrl_value_ammo.Value = (ctrl_value_ammo.Value +_ammo.Value).Max(ctrl_value_ammoMax.Value);
        AudioSystem.PlaySound(GeneralSounds.RELOAD);
        RefreshUiBullets();
    }


    private void RefreshUiBullets()
    {
        Transform _parent = ctrl_value_ui_parent_bullets.Value;
        int ammo = ctrl_value_ammo.Value;
        int max = _parent.childCount;
        bool hasBullets = !ammo.Equals(0);
        for (int i = 0; i < max; i++){
            bool _existBullet = i < ammo && hasBullets;
            _parent.GetChild(i).gameObject.SetActive(_existBullet);
        }

        ctrl_obj_mira.Value.SetActive(hasBullets);
    }
    #endregion
}
