using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateTilesTutorialEvent : TutorialEvent
{
    private Func<int> _createTilesAction;

    public CreateTilesTutorialEvent(Func<int> createTilesAction)
    {
        _createTilesAction = createTilesAction;
    }
    
    public override bool TryExecuteEvent()
    {
        _createTilesAction();
        return true;
    }
}
