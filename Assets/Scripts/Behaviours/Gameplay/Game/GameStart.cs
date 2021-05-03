using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStart : MonoBehaviour
{
    private GameChangeMonitor _gameChangeMonitor;
    private GameObject _paddle;
    private GameObject _ball;

    private void Awake()
    {
        Database.GameData.LoggedInProfile.NewGameStarted();
        _gameChangeMonitor = new GameChangeMonitor();
        _paddle = GameObject.Find("Paddle");

        // Save the starting positions of the Objects.
        _gameChangeMonitor.SaveGameChange(new PaddlePositionChange(_paddle.transform, Time.timeSinceLevelLoad,_paddle.transform.position));
        DontDestroyOnLoad(_paddle);
    }
}