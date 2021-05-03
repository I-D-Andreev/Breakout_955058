using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameReplayManager : MonoBehaviour
{
    private GameReplay _gameReplay;

    [SerializeField] private GameObject paddle;
    [SerializeField] private GameObject ball;
    [SerializeField] private GameObject exampleTile;
    [SerializeField] private GameObject gameEndMenu;
    
    private void Awake()
    {
        _gameReplay = new GameReplay(CurrentReplayData.ReplayData, paddle, ball, exampleTile);
        
    }
    
    void Update()
    {
        if (!_gameReplay.ReplayedAllChanges())
        {
            _gameReplay.ReplayChanges(Time.timeSinceLevelLoad);
        }
        else
        {
            gameEndMenu.SetActive(true);
        }
    }
}
