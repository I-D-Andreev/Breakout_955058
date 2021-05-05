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
    private GameObject _tilePrefab;
    
    
    public GameReplay(List<GameChange> gameChanges, GameObject paddle, GameObject ball, GameObject tilePrefab)
    {
        _currIndex = 0;
        _gameChanges = gameChanges;
        
        _paddle = paddle;
        _ball = ball;
        _tilePrefab = tilePrefab;

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
                
                case GameChange.GameChangeType.Tile:
                    _gameChanges[_currIndex].MakeChange(_tilePrefab);
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
