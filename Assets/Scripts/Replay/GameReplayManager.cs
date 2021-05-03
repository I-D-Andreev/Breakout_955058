using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameReplayManager : MonoBehaviour
{
    private GameReplay _gameReplay;
    
    private void Awake()
    {
        _gameReplay = CurrentGameReplay.GameReplay;
    }

    void Update()
    {
        if (!_gameReplay.ReplayedAllChanges())
        {
            _gameReplay.ReplayChanges(Time.timeSinceLevelLoad);
        }
    }
}
