using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavedGame
{
    private int _score;
    private int _timePlayed;
    // GameReplay

    public SavedGame(int score, int timePlayed)
    {
        _score = score;
        _timePlayed = timePlayed;
    }
    
    public int Score => _score;
    public int TimePlayed => _timePlayed;
}
