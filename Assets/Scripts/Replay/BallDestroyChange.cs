﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallDestroyChange : BallChange
{
    public BallDestroyChange(float time) : base(time)
    {
    }

    public override void MakeChange(GameObject gameObject)
    {
        Object.Destroy(gameObject);
    }
}
