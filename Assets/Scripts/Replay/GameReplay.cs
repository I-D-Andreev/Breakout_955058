using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameReplay
{
    private List<GameChange> _gameChanges;
    private int _currIndex;
    
    // references GameObjects
    private GameObject _paddle;
    private GameObject _ball;
    
    public GameReplay(List<GameChange> gameChanges, GameObject paddle, GameObject ball)
    {
        _currIndex = 0;
        _gameChanges = gameChanges;
        
        _paddle = paddle;
        _ball = ball;
    }

    public void ReplayChanges(float time)
    {
        while (!ReplayedAllChanges() && (time > _gameChanges[_currIndex].Time))
        {
            switch (_gameChanges[_currIndex].ChangeType())
            {
                case GameChange.GameChangeType.Paddle:
                    _gameChanges[_currIndex].MakeChange(_paddle);
                    break;
                
                case GameChange.GameChangeType.Ball:
                    _gameChanges[_currIndex].MakeChange(_ball);
                    break;
                
                default:
                    continue;
            }
            _currIndex++;
        }
    }

    public bool ReplayedAllChanges()
    {
        return (_currIndex >= _gameChanges.Count);
    }

}
