﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class SavedGame
{
    private int _score;
    // GameReplay

    public SavedGame(int score)
    {
        _score = score;
    }
    
    public int Score => _score;
}