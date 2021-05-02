using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerProfile
{
    // AchievementManager
    // List <SavedGame>

    private string _name;
    private int _gamesPlayed;

    public PlayerProfile(string playerName)
    {
        _gamesPlayed = 0;
        _name = playerName;
    }
    
    // public 

    public int GamesPlayed => _gamesPlayed;
    public string PlayerName => _name;
}
