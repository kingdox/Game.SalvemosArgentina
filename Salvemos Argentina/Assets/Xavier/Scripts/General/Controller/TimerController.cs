#region Access
using System;
using UnityEngine;
using XavHelpTo.Get;
using XavHelpTo.Know;
# endregion
[Serializable]
public class TimerController
{
    #region Variable
    private float count = 0;
    private float timer = 0;

    [SerializeField] Vector2 timerRange = default;
    #endregion
    #region Method
    public bool Timer()
    {
        if (timer.Equals(0)) timer = timerRange.Range();
        bool isTimeOut = timer.TimerIn(ref count);
        if (isTimeOut) timer = timerRange.Range();
        return isTimeOut;
    }
    #endregion
}