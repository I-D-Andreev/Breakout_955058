using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameChangeMonitor
{
    private static List<GameChange> _changes = new List<GameChange>();
    
    public void SaveAndMakeGameChange(GameChange gameChange)
    {
        SaveGameChange(gameChange);
        gameChange.MakeChange();
    }
    
    public void SaveGameChange(GameChange gameChange)
    {
        _changes.Add(gameChange);
    }

    public static List<GameChange> GameChanges => _changes;
}
