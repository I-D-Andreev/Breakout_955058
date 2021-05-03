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
        _ball = GameObject.Find("Ball");

        var paddlePos = _paddle.transform.position;
        _gameChangeMonitor.SaveGameChange(new PaddlePositionChange(0, paddlePos.x, paddlePos.y));

        var ballPos = _ball.transform.position;
        _gameChangeMonitor.SaveGameChange(new BallPositionChange(0, ballPos.x, ballPos.y));
    }
}