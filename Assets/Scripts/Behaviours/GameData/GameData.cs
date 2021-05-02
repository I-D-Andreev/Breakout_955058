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

    // public List<PlayerProfile> PlayerProfiles => _playerProfiles;
    public PlayerProfile LoggedInProfile => _loggedInProfile;


    public (PlayerProfile, string) CreateNewProfile(string playerName, int profilePanelPosition)
    {
        if (FindPlayerByName(playerName) is null)
        {
            PlayerProfile playerProfile = new PlayerProfile(playerName, profilePanelPosition);
            _playerProfiles.Add(playerProfile);
            return (playerProfile, "Profile successfully created!");
        }

        Debug.Log($"Name {playerName} already taken.");
        return (null, "Name is already taken!");
    }

    public void LogIn(string playerName)
    {
        _loggedInProfile = FindPlayerByName(playerName);
    }

    public void LogIn(PlayerProfile playerProfile)
    {
        _loggedInProfile = playerProfile;
    }

    public PlayerProfile FindPlayerByName(string playerName)
    {
        // Return the PlayerProfile with said name, or null if it doesn't exist.
        return _playerProfiles.FirstOrDefault(playerProfile => playerProfile.PlayerName.Equals(playerName));
    }

    public PlayerProfile FindPlayerByPanelPosition(int panelPosition)
    {
        return _playerProfiles.FirstOrDefault(playerProfile => playerProfile.ProfilePanelPosition == panelPosition);
    }

    public void DeleteProfile(PlayerProfile profile)
    {
        _playerProfiles.Remove(profile);
    }

    public void CalculateTop10Scores()
    {
        // Top 10 Score representation class
    }
}