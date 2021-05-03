using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameChangeMonitor
{
    private static List<GameChange> _changes = new List<GameChange>();
    
    public void SaveAndMakeGameChange(GameChange gameChange, GameObject gameObject)
    {
        SaveGameChange(gameChange);
        gameChange.MakeChange(gameObject);
    }
    
    public void SaveGameChange(GameChange gameChange)
    {
        _changes.Add(gameChange);
    }

    public static void NullifyGameChangeData()
    {
        _changes = new List<GameChange>();
    }
    
    public static List<GameChange> GameChanges => _changes;
}
