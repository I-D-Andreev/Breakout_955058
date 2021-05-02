using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GameChangeMonitor
{
    private static List<GameChange> _changes = new List<GameChange>();

    public abstract void AddGameChange(GameChange gameChange);
    
    public static List<GameChange> GameChanges => _changes;
}
