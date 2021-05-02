using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleChangeMonitor : GameChangeMonitor
{
    public override void AddGameChange(GameChange gameChange)
    {
        GameChanges.Add(gameChange);
        gameChange.MakeChange();
    }
}
