using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerProfile
{
    // AchievementManager
    private List<SavedGame> _savedGames;

    private string _name;
    private int _gamesPlayed;
    private int _profilePanelPosition; // which panel was this account created in

    public PlayerProfile(string playerName, int profilePanelPosition)
    {
        _savedGames = new List<SavedGame>();
        _gamesPlayed = 0;
        _name = playerName;
        _profilePanelPosition = profilePanelPosition;
    }

    public void NewGameStarted()
    {
        _gamesPlayed++;
    }

    public void EndedGame(int score, List<GameChange> gameReplayData)
    {
        if (Database.GameData.IsNewHighScore(score))
        {
            Debug.Log("Saving new high score: " + score);
            _savedGames.Add(new SavedGame(score, gameReplayData));
        }
    }

    public List<SavedGame> SavedGames => _savedGames;

    public int GamesPlayed => _gamesPlayed;
    public string PlayerName => _name;

    public int ProfilePanelPosition => _profilePanelPosition;
}
