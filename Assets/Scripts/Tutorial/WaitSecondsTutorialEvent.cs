using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitSecondsTutorialEvent : TutorialEvent
{
    private float _waitUpTo;
    private float _seconds;
    
    public WaitSecondsTutorialEvent(float seconds)
    {
        _seconds = seconds;
        _waitUpTo = 0;
    }
    
    public override bool TryExecuteEvent()
    {
        if (_waitUpTo == 0)
        {
            _waitUpTo = Time.realtimeSinceStartup + _seconds;
            return false;
        }
        
        return Time.realtimeSinceStartup >= _waitUpTo;
    }
}
