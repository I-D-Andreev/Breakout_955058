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

        _gameChangeMonitor.SaveGameChange(new PaddlePositionChange(Time.timeSinceLevelLoad,_paddle.transform.position));
    }
}