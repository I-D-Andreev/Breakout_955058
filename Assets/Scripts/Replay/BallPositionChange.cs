using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallPositionChange : BallChange
{
    private Vector2 _newPos;
    
    public BallPositionChange(float time, Vector2 newPos)
        : base(time)
    {
        _newPos = newPos;
    }
    
    public override void MakeChange(GameObject obj)
    {
        obj.transform.position = _newPos;
    }
}

