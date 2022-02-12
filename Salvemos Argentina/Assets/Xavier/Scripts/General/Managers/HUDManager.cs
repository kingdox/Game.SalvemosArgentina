#region
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using XavHelpTo;
using XavHelpTo.Get;
# endregion

public class HUDManager : MonoBehaviour
{
    #region Variables
    [Header("Goal")]
    [Space]
    [SerializeField] private Text text_goal_left;
    [SerializeField] private Text text_goal_right;

    [Header("Weapon")]
    [Space]
    [SerializeField] private Text text_goal_bullet;


    #endregion
    #region Events

    #endregion
    #region Method

    public void ChangeCounterGoals(Vector2Int v2)
    {

    }
    #endregion
}
