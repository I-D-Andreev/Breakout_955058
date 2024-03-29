﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerProfile
{
    private PlayerAchievements _playerAchievements;
    private List<SavedGame> _savedGames;

    private string _name;
    private int _gamesPlayed;
    private int _totalTilesDestroyed;
    private int _highestScore;
    
    private int _profilePanelPosition; // which panel was this account created in

    public PlayerProfile(string playerName, int profilePanelPosition)
    {
        _savedGames = new List<SavedGame>();
        _playerAchievements = new PlayerAchievements();
        _gamesPlayed = 0;
        _totalTilesDestroyed = 0;
        _highestScore = 0;
        _name = playerName;
        _profilePanelPosition = profilePanelPosition;
    }

    public void NewGameStarted()
    {
        _gamesPlayed++;
    }

    public void EndedGame(int score, List<GameChange> gameReplayData)
    {
        _highestScore = Math.Max(_highestScore, score);
        if (Database.GameData.IsNewHighScore(score))
        {
            Debug.Log("Saving new high score and Game Data: " + score + ", " + gameReplayData.Count);
            _savedGames.Add(new SavedGame(score, gameReplayData));
        }
    }

    public int TotalTilesDestroyed
    {
        get => _totalTilesDestroyed;
        set => _totalTilesDestroyed = value;
    }

    public int HighestScore => _highestScore;

    public PlayerAchievements PlayerAchievements => _playerAchievements;
    public List<SavedGame> SavedGames => _savedGames;

    public int GamesPlayed => _gamesPlayed;
    public string PlayerName => _name;

    public int ProfilePanelPosition => _profilePanelPosition;
}
