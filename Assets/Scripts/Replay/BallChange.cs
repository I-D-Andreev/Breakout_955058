using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BallChange : GameChange
{
    protected BallChange(float time) : base(time) { }

    public override GameChangeType ChangeType()
    {
        return GameChangeType.Ball;
    }
}
