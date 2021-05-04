using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitBallHitTileTutorialEvent : TutorialEvent
{
    private BoolWrapper _ballHitTile;

    public WaitBallHitTileTutorialEvent(BoolWrapper ballHitTile)
    {
        _ballHitTile = ballHitTile;
    }
    
    public override bool TryExecuteEvent()
    {
        return _ballHitTile.Value;
    }
}
