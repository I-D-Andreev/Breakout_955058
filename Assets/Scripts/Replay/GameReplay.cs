using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameReplay
{
    private List<GameChange> _gameChanges;
    private int _currIndex;

    public GameReplay() : this(new List<GameChange>())
    {
    }

    public GameReplay(List<GameChange> gameChanges)
    {
        _currIndex = 0;
        _gameChanges = gameChanges;
    }

    public void ReplayChanges(float time)
    {
        while (!ReplayedAllChanges() && (time > _gameChanges[_currIndex].Time))
        {
            _gameChanges[_currIndex].MakeChange();
            _currIndex++;
        }
    }

    public bool ReplayedAllChanges()
    {
        return (_currIndex >= _gameChanges.Count);
    }

}
