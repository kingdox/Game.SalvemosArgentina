#region Access
using System;
using UnityEngine;
using XavHelpTo;
using XavHelpTo.Change;
# endregion
[Serializable]
public class WeaponController
{
    private enum Bullet
    {
        Current,
        Max
    }
    //<T> where T : Component
    #region Variables
    [Header("Requirements")]
    [Space]
    [SerializeField] private Transform targetAim;
    [SerializeField] private Transform element;
    [Space]
    [SerializeField] private Vector2Int bullets;


    private int this[Bullet b] { get => bullets[b.ToInt()];
        set {
            bullets[b.ToInt()] = value;
        }
    }

    private bool CanShot => this[Bullet.Current] <= 0;
    #endregion
    #region Methods

    /// <summary>
    /// Shots a bullet in the specified direction
    /// </summary>
    public bool TryShot(out Transform bullet){
        if (!CanShot)
        {
            bullet = null;
            return false;
        }

        Vector3 _instancePos = targetAim.position + (targetAim.forward);
        Quaternion _instanceRotation = targetAim.rotation;
        bullet = UnityEngine.Object.Instantiate(
            element,
            _instancePos,
            _instanceRotation
        );
        return true;
    }
    #endregion
}
