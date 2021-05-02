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
    private int _profilePanelPosition; // which panel was this account created in

    public PlayerProfile(string playerName, int profilePanelPosition)
    {
        _gamesPlayed = 0;
        _name = playerName;
        _profilePanelPosition = profilePanelPosition;
    }
    
    // public 

    public int GamesPlayed => _gamesPlayed;
    public string PlayerName => _name;

    public int ProfilePanelPosition => _profilePanelPosition;
}
