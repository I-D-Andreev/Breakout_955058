using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class WaitKeyPressTutorialEvent : TutorialEvent
{
    private Key _key;

    public WaitKeyPressTutorialEvent(Key key)
    {
        _key = key;
    }
    
    public override bool TryExecuteEvent()
    {
        return Keyboard.current[_key].wasPressedThisFrame;
    }
}
