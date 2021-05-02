using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddlePositionChange : GameChange
{
    private Vector2 _newPos;
    
    public PaddlePositionChange(Transform transform, float time, Vector2 newPos)
        : base(transform, time)
    {
        _newPos = newPos;
    }
    
    public override void MakeChange()
    {
        this.Transform.position = _newPos;
    }
}
