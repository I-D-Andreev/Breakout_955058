using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameReplayManager : MonoBehaviour
{
    private GameReplay _gameReplay;

    [SerializeField] private GameObject paddle;
    
    
    private void Awake()
    {
        _gameReplay = new GameReplay(CurrentReplayData.ReplayData, paddle);
    }

    void Update()
    {
        if (!_gameReplay.ReplayedAllChanges())
        {
            _gameReplay.ReplayChanges(Time.timeSinceLevelLoad);
        }
    }
}
