using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallDeathChange : BallChange
{
    public BallDeathChange(float time) : base(time)
    {
    }

    public override void MakeChange(GameObject gameObject)
    {
        Object.Destroy(gameObject);
    }
}
