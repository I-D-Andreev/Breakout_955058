using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameReplay
{
    private List<GameChange> _gameChanges;
    private int _currIndex;
    // references GameObjects
    private GameObject _paddle;
    
    public GameReplay(List<GameChange> gameChanges, GameObject paddle)
    {
        _currIndex = 0;
        _gameChanges = gameChanges;
        
        _paddle = paddle;
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
