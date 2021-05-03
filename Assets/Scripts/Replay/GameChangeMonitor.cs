using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameChangeMonitor
{
    private static List<GameChange> _changes = new List<GameChange>();
    private static bool _isLocked;
    
    public void SaveAndMakeGameChange(GameChange gameChange, GameObject gameObject)
    {
        SaveGameChange(gameChange);
        gameChange.MakeChange(gameObject);
    }
    
    public void SaveGameChange(GameChange gameChange)
    {
        if (gameChange.Time == 0)
        {
            _isLocked = false;
        }
        
        if (!_isLocked)
        {
            _changes.Add(gameChange);
        }
    }

    public static void NullifyGameChangeData()
    {
        _isLocked = true;
        _changes = new List<GameChange>();
    }
    
    public static List<GameChange> GameChanges => _changes;
}
