#region Access
using System;
using UnityEngine;
using UnityEngine.Events;
using XavHelpTo.Get;
using XavHelpTo.Know;
# endregion
[Serializable]
public class TimerController
{
    #region Variable
    private float count = 0;
    private float timer = 0;
    //private bool flag = false;

    //[SerializeField] private bool LockWhenTimeOut = default;
    [SerializeField] private Vector2 timerRange = default;
    //[SerializeField] private UnityEvent timerAction = default;
    #endregion
    #region Method
    public bool Timer()
    {
        if (timer.Equals(0)) timer = timerRange.Range();



        bool isTimeOut = timer.TimerIn(ref count);
        _TimerCompleted(isTimeOut);
        return isTimeOut;
    }

    private void _TimerCompleted(bool isTimeOut){
        if (!isTimeOut) return;
        timer = timerRange.Range();
        //timerAction?.Invoke();
    }
    #endregion
}