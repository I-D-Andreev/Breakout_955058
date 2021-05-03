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

    private float _firstFrameTime; 
    
    private void Awake()
    {
        _gameReplay = new GameReplay(CurrentReplayData.ReplayData, paddle, ball, exampleTile);
        
    }

    // private void OnEnable()
    // {
    //     _firstFrameTime = -1;
    // }

    void Update()
    {
        // if (Math.Abs(_firstFrameTime - (-1)) < 0.1)
        // {
        //     _firstFrameTime = Time.timeSinceLevelLoad;
        //     Debug.Log("GamePlayManager first frame: " + _firstFrameTime);
        // }
        
        if (!_gameReplay.ReplayedAllChanges())
        {
            _gameReplay.ReplayChanges(Time.timeSinceLevelLoad - _firstFrameTime);
        }
        else
        {
            gameEndMenu.SetActive(true);
        }
    }
}
