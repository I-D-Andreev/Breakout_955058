using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStart : MonoBehaviour
{
    private GameObject _paddle;
    private GameObject _ball;

    private void Awake()
    {
        Database.GameData.LoggedInProfile.NewGameStarted();
        _paddle = GameObject.Find("Paddle");
        _ball = GameObject.Find("Ball");

        AchievementsManager.ShouldMonitor = true;
        GameChangeMonitor.ShouldMonitor = true;
        var paddlePos = _paddle.transform.position;
        GameChangeMonitor.SaveGameChange(new PaddlePositionChange(0, paddlePos.x, paddlePos.y));

        var ballPos = _ball.transform.position;
        GameChangeMonitor.SaveGameChange(new BallPositionChange(0, ballPos.x, ballPos.y));
    }
}