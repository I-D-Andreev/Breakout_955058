using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameChangeMonitor
{
    private static List<GameChange> _changes = new List<GameChange>();
    private static bool _shouldMonitor = false;

    public static void SaveAndMakeGameChange(GameChange gameChange, GameObject gameObject)
    {
        SaveGameChange(gameChange);
        gameChange.MakeChange(gameObject);
    }

    public static void SaveGameChange(GameChange gameChange)
    {
        if (_shouldMonitor)
        {
            _changes.Add(gameChange);
        }
    }

    public static void NullifyGameChangeData()
    {
        // Lock the List so that no new trash data is added after game end (as some events might end after GameEnd).
        ShouldMonitor = false;
        _changes = new List<GameChange>();
    }

    public static List<GameChange> GameChanges => _changes;

    public static bool ShouldMonitor
    {
        get => _shouldMonitor;
        set
        {
            _shouldMonitor = value;  
            Debug.Log("Should monitor: " + _shouldMonitor);
        }
    }
}