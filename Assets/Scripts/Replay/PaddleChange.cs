using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class PaddleChange : GameChange
{
    protected PaddleChange(float time) : base(time) { }

    public override GameChangeType ChangeType()
    {
        return GameChangeType.Paddle;
    }
    
}
