﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BallPositionChange : BallChange
{
    private float _posX;
    private float _posY;
    
    public BallPositionChange(float time, float posX, float posY)
        : base(time)
    {
        _posX = posX;
        _posY = posY;
    }
    
    public override void MakeChange(GameObject obj)
    {
        obj.transform.position = new Vector3(_posX, _posY, 0);
    }
}

