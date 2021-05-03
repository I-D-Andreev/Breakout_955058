using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameChangeMonitor
{
    private static List<GameChange> _changes = new List<GameChange>();
    private static bool _isLocked;
    
    public static void SaveAndMakeGameChange(GameChange gameChange, GameObject gameObject)
    {
        SaveGameChange(gameChange);
        gameChange.MakeChange(gameObject);
    }
    
    public static void SaveGameChange(GameChange gameChange)
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
        // Lock the List so that no new trash data is added after game end (as some events might end after GameEnd).
        _isLocked = true;
        _changes = new List<GameChange>();
    }
    
    public static List<GameChange> GameChanges => _changes;
}
