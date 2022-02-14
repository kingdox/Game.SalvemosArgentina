using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XavHelpTo;
using XavHelpTo.Get;
using XavHelpTo.Change;
using XavHelpTo.Set;
using XavHelpTo.Know;

/// <summary>
/// - El enemigo apuntará a la bola siempre
/// - CUando pueda disparar lo hará
/// - tiene un cooldown que le bloquea disparar, y este es random
/// - El enemigo se mueve de izquierda a derecha aleatoriamente
/// </summary>
public class EnemyEntity : MonoBehaviour
{
    #region Variables

    [Header("Atributes")]
    [Space]
    //[SerializeField] private Transform pos_shot;
    [SerializeField] private Transform tr_parent_pos;
    [SerializeField] private Transform tr_ball; // a apuntar
    [SerializeField] private float speed;
    [SerializeField] private Vector3 posToGo;
    [SerializeField] private ValueController<ParticleSystem> ctrl_particle_shot;

    [Header("Features")]
    [Space]
    //[SerializeField] private RayCastController ctrl_ray_ball;
    [SerializeField] private TimerController ctrl_timer;
    [SerializeField] private TimerController ctrl_timer_changePosition;
    //[SerializeField] private 

    #endregion
    #region Events
    private void Start()
    {
        ChangeMovement();
    }
    private void Update(){
        if (Time.timeScale.Equals(0)) return;
        LookBall();
        Move();
        if (ctrl_timer.Timer()) Shot();
        if (ctrl_timer_changePosition.Timer()) ChangeMovement();
    }
    #endregion
    #region Methods
    private void LookBall()
    {
        transform.LookAt(tr_ball, Vector3.up);
    }
    private void ChangeMovement()
    {
        int counts = tr_parent_pos.childCount;
        int posToGoIndex = counts.ZeroMax();
        float Y = transform.position.y;
        posToGo = tr_parent_pos.GetChild(posToGoIndex).position.Axis(1, Y);
    }
    private void Move(){
        Vector3 pos = Vector3.Lerp(
            transform.position,
            posToGo,
            speed * Time.deltaTime
        );
        transform.position = pos;
    }
    private void Shot(){
        Transform t = tr_ball;
        //Transform  t = ctrl_ray_ball.CastRay();
        AudioSystem.PlaySound(GeneralSounds.SHOT);
        if (t)
        {
            t.Component(out BallEntity _ball);
            _ball.ApplyForce(transform.position);
            AudioSystem.PlaySound(GeneralSounds.SHOT_BALL);
            ctrl_particle_shot.Value.Play();
        }

    }
    #endregion
}
