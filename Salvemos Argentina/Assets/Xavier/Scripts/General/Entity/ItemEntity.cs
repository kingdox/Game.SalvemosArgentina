#region Access
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XavHelpTo;
using XavHelpTo.Get;
# endregion

public class ItemEntity : ComponentBase
{
    #region Variable
    [Header("Stats")]
    [SerializeField] private ValueController<int> ammoQtyEarn;

    [Header("Requirements")]
    [Space]
    [SerializeField] private RotationController ctrl_rotation;
    [SerializeField] private ContactTypeController<PlayerEntity> ctrl_player;

    #endregion
    #region Event
    private void Update()
    {
        ctrl_rotation.Rotate();
    }
    private void OnTriggerEnter(Collider other)
    {
        ctrl_player.Check(in other, OnCollisionWithPlayer);


    }
    #endregion
    #region Method
    protected override void Suscribe(bool condition)
    {
    }

    private void OnCollisionWithPlayer(PlayerEntity p){
        //$"Colisionado con {p.name}".Print("green");
        p.GetAmmo(ammoQtyEarn);
        Destroy(gameObject);
    }
    #endregion
}
