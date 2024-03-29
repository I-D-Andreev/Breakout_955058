﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class TileChange : GameChange
{
    protected TileChange(float time) : base(time) { }

    public override GameChangeType ChangeType()
    {
        return GameChangeType.Tile;
    } 
}
