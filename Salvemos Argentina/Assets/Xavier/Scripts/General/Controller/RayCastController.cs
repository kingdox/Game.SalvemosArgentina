#region Access
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XavHelpTo;
using XavHelpTo.Get;
# endregion

[Serializable]
public class RayCastController
{
    #region Variables
    [SerializeField] private Transform target;
    [SerializeField] private LayerMask layer;
    #endregion
    #region Events
    #endregion
    #region Methods

    public Transform CastRay()
    {
        Transform result = null;
        //RaycastHit();
        if (Physics.Raycast(target.position, target.forward, out RaycastHit hit, float.MaxValue, layer)){
            //hit.transform.name.Print("red");
            result = hit.transform;
        }
        return result;
    }
    #endregion
}
