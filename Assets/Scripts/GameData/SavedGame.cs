using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class SavedGame
{
    private int _score;
    private List<GameChange> _gameChanges;

    public SavedGame(int score, List<GameChange> gameReplayData)
    {
        _score = score;
        _gameChanges = gameReplayData;
    }
    
    public int Score => _score;
    public List<GameChange> GameReplayData => _gameChanges;
}
