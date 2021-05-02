using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[Serializable]
public class GameData
{
    private List<PlayerProfile> _playerProfiles;
    private PlayerProfile _loggedInProfile;
    

    public GameData()
    {
        _playerProfiles = new List<PlayerProfile>();
        _loggedInProfile = null;
    }

    public PlayerProfile GetLoggedInUser => _loggedInProfile;

    public (bool, string) CreateNewProfile(string playerName)
    {
        if (FindPlayerByName(playerName) is null)
        {
            Debug.Log($"Name {playerName} already taken.");
            return (false, "Name is already taken!");
        }
        
        _playerProfiles.Add(new PlayerProfile(playerName));
        return (true, "Profile successfully created!");
    }

    public void LogIn(string playerName)
    {
        _loggedInProfile = FindPlayerByName(playerName);
    }

    private PlayerProfile FindPlayerByName (string playerName)
    {
        // Return the PlayerProfile with said name, or null if it doesn't exist.
        return _playerProfiles.FirstOrDefault(playerProfile => playerProfile.PlayerName.Equals(playerName));
    }

    public void CalculateTop10Scores()
    {
        // Top 10 Score representation class
    }
}
